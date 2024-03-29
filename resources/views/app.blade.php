<!DOCTYPE html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}" class="h-screen flex flex-col">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <title inertia>{{ config('app.name', 'Laravel') }}</title>

  <!-- Fonts -->
  <link rel="preconnect" href="https://fonts.bunny.net">
  <link href="https://fonts.bunny.net/css?family=figtree:400,500,600&display=swap" rel="stylesheet" />

  <!-- Scripts -->
  @routes
  @vite(['resources/ts/app.ts', "resources/ts/Pages/{$page['component']}.vue"])
  @inertiaHead
</head>

<body class="font-sans antialiased text-neutral-800 bg-neutral-50 h-full flex-1 flex flex-col">
  @inertia
</body>

</html>
