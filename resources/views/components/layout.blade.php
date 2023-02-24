<!DOCTYPE html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <title>Budgeteer</title>

  <!-- Styles -->

  <link rel="stylesheet" type="text/css" href="index.bundle.css" />

  @if (isset($additionalStyles))
    {{ $additionalStyles }}
  @endif

  <link type="text/css" rel="stylesheet" href="app.css" />
</head>

<body class="min-h-screen text-slate-200 flex flex-col">
  <x-header></x-header>

  <main class="flex-1">
    {{ $slot }}
  </main>

  <x-footer></x-footer>

  <script src="index.bundle.js"></script>

  @if (isset($additionalScripts))
    {{ $additionalScripts }}
  @endif
</body>

</html>
