<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class () extends Migration {
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('budget_plan', function (Blueprint $table) {
            $table->id();
            $table->timestamps(4);

            $table->string('name');
            $table->text('description');
        });

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

        Schema::create('budget_categories', function (Blueprint $table) {
            $table->id();
            $table->timestamps(4);
            $table->string('name');
            $table->text('description');
            $table->string('slug')->unique();

            $table->foreignId('parent_id')->nullable()->constrained('budget_categories');
            $table->foreignIdFor(User::class)->constrained();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('budget_plan');
        Schema::dropIfExists('budgets');
        Schema::dropIfExists('transactions');
        Schema::dropIfExists('budget_categories');
    }
};
