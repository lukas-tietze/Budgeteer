<?php

namespace App\Http\Controllers;

use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Foundation\Validation\ValidatesRequests;
use Illuminate\Support\Facades\Route;

use App\Http\Controllers\Controller;
use App\Models\BudgetCategory;

class BudgetCategoryController extends Controller
{
    use AuthorizesRequests;
    use ValidatesRequests;

    public function Index()
    {
        $models = BudgetCategory::all()->toArray();

        $models = array_map(function ($item) {
            return [
              'name' => $item['name'],
            ];
        }, $models);

        return parent::Render('BudgetCategories/Index', ['budgeCategories' => $models]);
    }

    public function Add()
    {
        $models = BudgetCategory::all()->toArray();

        $models = array_map(function ($item) {
            return [
              'name' => $item['name'],
              'id' => $item['id'],
              'parentId' => $item['parent_id'],
            ];
        }, $models);

        return parent::Render('BudgetCategories/Add', ['budgeCategories' => $models]);
    }
}
