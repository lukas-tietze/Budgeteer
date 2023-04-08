<?php

<<<<<<< HEAD
use Illuminate\Support\Facades\Route;

use App\Models\Budget;
use App\Models\Transaction;
=======
use Illuminate\Foundation\Application;
use Illuminate\Support\Facades\Route;
use Inertia\Inertia;
>>>>>>> 8ec4326 (Re-Init)

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
<<<<<<< HEAD
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "web" middleware group. Make something great!
=======
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
>>>>>>> 8ec4326 (Re-Init)
|
*/

Route::get('/', function () {
<<<<<<< HEAD
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
=======
    return Inertia::render('Welcome', [
      'canLogin' => Route::has('login'),
      'canRegister' => Route::has('register'),
      'laravelVersion' => Application::VERSION,
      'phpVersion' => PHP_VERSION,
    ]);
});

Route::get('/playground', function () {
    return Inertia::render('Playground', [
      'time' => now()->toTimeString()
    ]);
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
>>>>>>> 8ec4326 (Re-Init)
