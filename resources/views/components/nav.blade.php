<nav class="flex flex-row">
  <ul class="list-none flex flex-row">
    <x-nav-item href="/">
      <i class="fa-solid fa-home"></i>

      <span>BUDGETEER</span>
    </x-nav-item>
  </ul>

  <div class="flex-1"></div>

  <ul class="list-none flex flex-row">
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
