<?php

namespace Database\Seeders;

// use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

use App\Models\User;
use App\Models\Transaction;
use App\Models\Budget;
use App\Models\BudgetCategory;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        $users = User::factory(10)->create();

        foreach ($users as $user) {
            $categories = BudgetCategory::factory(3)->create([
              'user_id' => $user->id,
            ]);

            foreach ($categories as $category) {
                $n = fake()->numberBetween(20, 200);

                Transaction::factory($n)->create([
                  'user_id' => $user->id,
                  'budget_category_id' => $category->id,
                ]);

                $n = fake()->numberBetween(2, 5);

                Budget::factory($n)->create([
                  'user_id' => $user->id,
                  'budget_category_id' => $category->id,
                ]);
            }
        }
    }
}
