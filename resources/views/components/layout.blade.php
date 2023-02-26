<!DOCTYPE html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <title>Budgeteer</title>

  <!-- Styles -->
  @vite(['resources/scss/app.scss', 'resources/ts/app.ts'])

  @if (isset($additionalStyles))
    @foreach ($additionalStyles as $additionalStyle)
      @vite([$additionalStyle]);
    @endforeach
  @endif

  @if (isset($additionalScripts))
    {{ $additionalScripts }}
  @endif
</head>

<body class="min-h-screen text-slate-200 flex flex-col">
  <x-header></x-header>

  <main class="flex-1">
    {{ $slot }}
  </main>

  <x-footer></x-footer>
</body>

</html>
