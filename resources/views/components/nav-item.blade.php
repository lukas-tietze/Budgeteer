<li class="hover:bg-emerald-700">
  <a href="{{ isset($href) ? $href : '' }}" class="hover:underline">
    <div class="p-3">
      {{ $slot }}
    </div>
  </a>
</li>
