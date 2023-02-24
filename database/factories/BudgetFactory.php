<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

use App\Models\User;
use App\Models\BudgetCategory;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Budget>
 */
class BudgetFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        $valid1 = fake()->dateTimeBetween('-1 year, +1 year');
        $valid2 = fake()->dateTimeBetween('-1 year, +1 year');

        return [
          'amount' => fake()->numberBetween(10, 2_000),
          'slug' => fake()->slug(),
          'valid_from' => min($valid1, $valid2),
          'valid_to' => max($valid1, $valid2),
          'interval' => 1,

          'user_id' => User::factory(),
          'budget_category_id' => BudgetCategory::factory(),
        ];
    }
}
