<?php

namespace App\Http\Controllers;

use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Foundation\Validation\ValidatesRequests;
use Illuminate\Support\Facades\Route;
use Illuminate\Http\Request;
use Illuminate\Support\Str;

use App\Http\Controllers\Controller;
use App\Models\BudgetCategory;

// https://laravel.com/docs/10.x/controllers#actions-handled-by-resource-controller

class BudgetCategoryController extends Controller
{
    use AuthorizesRequests;
    use ValidatesRequests;

    public function array_find_index(array $array, $test)
    {
        foreach ($array as $key => $value) {
            if (call_user_func($test, $value) === true) {
                return $key;
            }
        }

        return null;
    }

    public function index()
    {
        $models = BudgetCategory::all()->toArray();

        $models = array_map(function ($item) {
            return [
              'name' => $item['name'],
              'id' => $item['id'],
              'parentId' => $item['parent_id'],
              'slug' => $item['slug'],
            ];
        }, $models);

        return parent::Render('BudgetCategories/Index', ['budgetCategories' => $models]);
    }

    public function edit(string $slug)
    {
        // TODO: User-ID beachten
        $budgetCategories = BudgetCategory::all()->toArray();

        $entityIndex = $this->array_find_index($budgetCategories, function ($item) use ($slug) {
            return $item['slug'] === $slug;
        });

        $entity = array_splice($budgetCategories, $entityIndex, 1)[0];
        $budgetCategories = array_map(function ($item) {
            return [
              'name' => $item['name'],
              'id' => $item['id'],
              'parentId' => $item['parent_id'],
            ];
        }, $budgetCategories);

        return parent::Render('BudgetCategories/Edit', [
          'budgetCategories' => $budgetCategories,
          'model' => [
            'name' => $entity['name'],
            'id' => $entity['id'],
            'parentId' => $entity['parent_id'],
            'slug' =>$entity['slug'],
          ]
        ]);
    }

    public function update(string $slug, Request $request)
    {
        $attrs = $request->validate([
          'name' => 'required',
        ]);

        BudgetCategory::where('slug', $slug)
          ->update([
            'name' => $attrs['name'],
            'description' => strval($request->input('description') ?? ''),
            'slug' => $this->createUniqueSlug($attrs['name']),
            'parent_id' => $request->input('parentId')
          ]);

        return redirect('/budget-categories');
    }

    public function destroy(string $slug)
    {
        BudgetCategory::where('slug', $slug)->delete();

        return redirect('/budget-categories');
    }

    public function store(Request $request)
    {
        $this->middleware('auth');
        $this->middleware('log');

        $attrs = $request->validate([
          'name' => 'required',
        ]);

        // TODO: Id des aktuellen Nutzers.
        $attrs['user_id'] = 1;
        $attrs['description'] = strval($request->input('description') ?? '');
        $attrs['slug'] = $this->createUniqueSlug($attrs['name']);

        BudgetCategory::create($attrs);

        return redirect('/budget-categories');
    }

    public function create()
    {
        $models = BudgetCategory::all()->toArray();

        $models = array_map(function ($item) {
            return [
              'name' => $item['name'],
              'id' => $item['id'],
              'parentId' => $item['parent_id'],
            ];
        }, $models);

        return parent::Render('BudgetCategories/Edit', [
          'model' => null,
          'budgetCategories' => $models
        ]);
    }

    private function createUniqueSlug(string $name)
    {
        $slug = Str::slug($name);

        $existing = BudgetCategory::whereRaw("slug LIKE '{$slug}%'")
          ->addSelect('slug')
          ->get()
          ->toArray();

        $count = 0;
        $uniqueSlug = $slug;

        while (in_array($slug, $existing)) {
            $uniqueSlug = "{$slug}_{++$count}";
        }

        return $uniqueSlug;
    }
}
