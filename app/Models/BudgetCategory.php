<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class BudgetCategory extends Model
{
    use HasFactory;

    protected $guarded = [];

    public function parentCategory()
    {
        return $this->belongsTo(BudgetCategory::class);
    }
}
