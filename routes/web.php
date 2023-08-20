<?php

use Illuminate\Foundation\Application;
use Illuminate\Support\Facades\Route;
use Inertia\Inertia;

use App\Models\Budget;
use App\Models\Transaction;

use  App\Http\Controllers\BudgetCategoryController;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

function RenderPage($pageName, $values)
{
    $defaultValues = [
      'canLogin' => Route::has('login'),
      'canRegister' => Route::has('register'),
      'laravelVersion' => Application::VERSION,
      'phpVersion' => PHP_VERSION,
    ];

    return Inertia::render($pageName, array_merge($defaultValues, $values));
}

Route::get('/', function () {
    return RenderPage('Index', []);
});

Route::get('/budgets', function () {
    return RenderPage('Budgets', []);
});

Route::resource('/budget-categories', BudgetCategoryController::class);

Route::get('/transactions', function () {
    return RenderPage('Transactions', []);
});

Route::middleware([
    'auth:sanctum',
    config('jetstream.auth_session'),
    'verified',
])->group(function () {
    Route::get('/dashboard', function () {
        return Inertia::render('Dashboard');
    })->name('dashboard');
});

Route::post('/logout', function () {
    dd('logging the user out -> '. request('foo'));
});
