<?php

namespace Database\Factories;

use Illuminate\Database\Eloquent\Factories\Factory;

use App\Models\User;

/**
 * @extends \Illuminate\Database\Eloquent\Factories\Factory<\App\Models\Transaction>
 */
class TransactionFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
            'user_id' => User::factory(),
            'moment' => fake()->dateTimeBetween('-1 year', 'now'),
            'amount' => fake()->numberBetween(-99_999, 99_999),
            'usage' => fake()->words(3, true),
            'target' => fake()->name(),
            'budget_category_id' => null,
        ];
    }
}
