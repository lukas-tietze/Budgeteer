<?php

namespace App\Http\Controllers;

use Illuminate\Support\Facades\Route;
use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Foundation\Validation\ValidatesRequests;
use Illuminate\Foundation\Application;
use Illuminate\Routing\Controller as BaseController;

use Inertia\Inertia;

class Controller extends BaseController
{
    use AuthorizesRequests;
    use ValidatesRequests;

    protected function Render($pageName, $values)
    {
        $defaultValues = [
          'canLogin' => Route::has('login'),
          'canRegister' => Route::has('register'),
          'laravelVersion' => Application::VERSION,
          'phpVersion' => PHP_VERSION,
        ];

        return Inertia::render($pageName, array_merge($defaultValues, $values));
    }
}
