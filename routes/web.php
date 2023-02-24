<?php

use Illuminate\Support\Facades\Route;

use App\Models\Budget;
use App\Models\Transaction;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "web" middleware group. Make something great!
|
*/

Route::get('/', function () {
    return view('pages/index');
});

Route::get('/budgets', function () {
    return view('pages/budgets', [
      'budgets' => Budget::all(),
    ]);
});

Route::get('/transactions', function () {
    return view('pages/transactions', [
      'transactions' => DB::table('transactions')->orderBy('moment', 'desc')->get(),
    ]);
});
