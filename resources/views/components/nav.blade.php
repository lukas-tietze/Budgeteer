<nav class="flex flex-row">
  <ul class="list-none flex flex-row flex-1 justify-start">
    <x-nav-item href="/">
      <i class="fa-solid fa-home"></i>

      <span>BUDGETEER</span>
    </x-nav-item>
  </ul>

  <ul class="list-none flex flex-row flex-1 justify-center">
    <x-nav-item href="/budgets">
      <span>Budgets</span>
    </x-nav-item>

    <x-nav-item href="/budget-categories">
      <span>Kategorien</span>
    </x-nav-item>

    <x-nav-item href="/transactions">
      <span>Einnahmen & Ausgaben</span>
    </x-nav-item>
  </ul>

  <ul class="list-none flex flex-row flex-1 justify-end">
    {{-- TODO: Unterscheidung eingeloggt / nicht eingeloggt einbauen --}}

    <x-nav-item href="/">
      <i class="fa-solid fa-circle-user"></i>
      <span>Profil</span>
    </x-nav-item>

    <x-nav-item href="/">
      <i class="fa-solid fa-arrow-right-from-bracket"></i>
      <span>Abmelden</span>
    </x-nav-item>
  </ul>
</nav>
