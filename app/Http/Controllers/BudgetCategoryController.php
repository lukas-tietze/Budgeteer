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

    public function index()
    {
        $models = BudgetCategory::all()->toArray();

        $models = array_map(function ($item) {
            return [
              'name' => $item['name'],
              'id' => $item['id'],
              'parentId' => $item['parent_id'],
            ];
        }, $models);

        return parent::Render('BudgetCategories/Index', ['budgetCategories' => $models]);
    }

    public function store(Request $request)
    {
        $this->middleware('auth');
        $this->middleware('log');

        $attrs = $request->validate([
          'name' => 'required',
        ]);

        $attrs['user_id'] = 1;
        $attrs['description'] = strval($request->input('description') ?? '');
        $attrs['slug'] = Str::slug($attrs['name']);

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

        return parent::Render('BudgetCategories/Add', ['budgetCategories' => $models]);
    }
}
