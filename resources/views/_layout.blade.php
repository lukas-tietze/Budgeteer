<!DOCTYPE html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <title>Budgeteer</title>

  <!-- Styles -->

  @yield('additional-styles')

  <link type="text/css" rel="stylesheet" href="app.css" />
</head>

<body>
  @include('./partials/header')

  <main>
    @yield('content')
  </main>

  @include('./partials/footer')

  @yield('additional-scripts')
</body>

</html>
