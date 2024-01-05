<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

use \App\Models\User;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\BudgetCategory>
 */
class BudgetCategoryFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
          'name' => fake()->name(),
          'description' => '',
          'slug' => fake()->slug(),
          'parent_id' => null,
          'user_id' => User::factory(),
        ];
    }
}
