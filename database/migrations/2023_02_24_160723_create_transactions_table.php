<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

use App\Models\User;
use App\Models\BudgetCategory;

return new class () extends Migration {
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('transactions', function (Blueprint $table) {
            $table->id();
            $table->timestamps(4);
            $table->dateTime('moment', 4);
            $table->integer('amount');
            $table->text('usage');
            $table->text('target');

            $table->foreignIdFor(User::class)->constrained();
            $table->foreignIdFor(BudgetCategory::class)->constrained()->nullable();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('transactions');
    }
};
