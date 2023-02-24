<?php

use App\Models\User;
use App\Models\BudgetCategory;
use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
  /**
   * Run the migrations.
   */
  public function up(): void
  {
    Schema::create('budgets', function (Blueprint $table) {
      $table->id();
      $table->timestamps(4);
      $table->unsignedBigInteger('amount');
      $table->tinyInteger('interval');
      $table->string('slug')->unique();
      $table->dateTime('valid_from', 4);
      $table->dateTime('valid_to', 4);

      $table->foreignIdFor(BudgetCategory::class)->constrained();
      $table->foreignIdFor(User::class)->constrained();
    });
  }

  /**
   * Reverse the migrations.
   */
  public function down(): void
  {
    Schema::dropIfExists('budgets');
  }
};
