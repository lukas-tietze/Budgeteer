<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

use App\Models\User;
use App\Models\BudgetCategory;

class Transaction extends Model
{
    use HasFactory;

    protected $fillable = [
      'moment',
      'amount',
      'usage',
      'target'
    ];


    public function user()
    {
        return $this->belongsTo(User::class);
    }

    public function category()
    {
        return $this->belongsTo(BudgetCategory::class);
    }
}
