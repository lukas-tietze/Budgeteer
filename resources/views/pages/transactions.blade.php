<x-layout>
  <h1>Einnahmen & Ausgaben</h1>

  <div class="mx-auto max-w-5xl text-slate-700">
    @foreach ($transactions as $transaction)
      @php($isPay = $transaction->amount < 0)

      <a href="/transactions/{{ $transaction->id }}" class="contents">
        <div class="flex flex-col bg-emerald-100/50 hover:bg-emerald-300/50 p-10 rounded-md shadow-sm mb-10">
          <div class="flex flex-row justify-between">
            <div>{{ $transaction->target }}</div>
            <div>{{ $transaction->moment }}</div>
          </div>

          <div class="{{ $isPay ? 'text-red-500' : 'text-emerald-500' }} row-span-2 text-xl mt-5">
            <b>
              {{ $isPay ? '-' : '+' }}
              {{ number_format((($isPay ? -1 : 1) * $transaction->amount) / 100, 2) }} &euro;
            </b>
          </div>
        </div>
      </a>
    @endforeach
  </div>
</x-layout>
