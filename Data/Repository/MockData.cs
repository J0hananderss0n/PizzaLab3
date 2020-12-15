using Data.Models;
using System.Collections.Generic;

namespace Data.Repository
{
    public class MockData
    {
        private static MockData _instance;

        public static MockData GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MockData();
            }
            return _instance;
        }
        private MockData()
        {
            SetMenuList();
            SetIngredientsList();
        }

        public List<MenuItem> MenuList { get; set; }
        public List<Ingredient> IngredientsList { get; set; }


        private void SetMenuList()
        {
            MenuList = new List<MenuItem>()
        {
            new MenuItem
            {
                MenuItemId = 1,
                Name = "Margerita",
                Cost = 85,
                Type = "Pizza",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient {IngredientId = 11, Name = "Ost", Cost = 0},
                    new Ingredient {IngredientId = 12, Name = "Tomatsås", Cost = 0}
                }
            },
            new MenuItem
            {
                MenuItemId = 2,
                Name = "Hawaii",
                Cost = 95,
                Type = "Pizza",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient {IngredientId = 11, Name = "Ost", Cost = 0},
                    new Ingredient {IngredientId = 12, Name = "Tomatsås", Cost = 0},
                    new Ingredient {IngredientId = 1, Name = "Skinka", Cost = 0},
                    new Ingredient {IngredientId = 2, Name = "Ananas", Cost = 0}
                }
            },
            new MenuItem
            {
                MenuItemId = 3,
                Name = "Kebabpizza ",
                Cost = 105,
                Type = "Pizza",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient {IngredientId = 11, Name = "Ost", Cost = 0},
                    new Ingredient {IngredientId = 12, Name = "Tomatsås", Cost = 0},
                    new Ingredient {IngredientId = 9, Name = "Kebab", Cost = 0},
                    new Ingredient {IngredientId = 3, Name = "Champinjoner", Cost = 0},
                    new Ingredient {IngredientId = 4, Name = "Lök", Cost = 0},
                    new Ingredient {IngredientId = 13, Name = "Feferoni", Cost = 0},
                    new Ingredient {IngredientId = 14, Name = "Isbergssallad", Cost = 0},
                    new Ingredient {IngredientId = 15, Name = "Tomat", Cost = 0},
                    new Ingredient {IngredientId = 5, Name = "Kebabsås ", Cost = 0}
                }
            },
            new MenuItem
            {
                MenuItemId = 4,
                Name = "Quatro Stagioni",
                Cost = 115,
                Type = "Pizza",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient {IngredientId = 11, Name = "Ost", Cost = 0},
                    new Ingredient {IngredientId = 12, Name = "Tomatsås", Cost = 0},
                    new Ingredient {IngredientId = 1, Name = "Skinka", Cost = 0},
                    new Ingredient {IngredientId = 6, Name = "Räkor", Cost = 0},
                    new Ingredient {IngredientId = 7, Name = "Musslor", Cost = 0},
                    new Ingredient {IngredientId = 3, Name = "Champinjoner", Cost = 0},
                    new Ingredient {IngredientId = 8, Name = "Kronärtskocka ", Cost = 0}
                }

            },
            new MenuItem
            {
                MenuItemId = 5,
                Type = "Soda",
                Name = "Coca Cola",
                Cost = 20
            },
            new MenuItem
            {
                MenuItemId = 6,
                Type = "Soda",
                Name = "Fanta",
                Cost = 20
            },
            new MenuItem
            {
                MenuItemId = 7,
                Type = "Soda",
                Name = "Sprite",
                Cost = 25
            },
            
        };
        }

        private void SetIngredientsList()
        {
            IngredientsList = new List<Ingredient>()
        {
            new Ingredient
            {
                IngredientId = 1,
                Name = "Skinka",
                Cost = 10
            },
            new Ingredient
            {
                IngredientId = 2,
                Name = "ananas",
                Cost = 10
            },
            new Ingredient
             {
                 IngredientId = 3,
                 Name = "champinjoner",
                 Cost = 10
             },
            new Ingredient
            {
                IngredientId = 4,
                Name = "lök",
                Cost = 10
            },
            new Ingredient
            {
                IngredientId = 5,
                Name = "kebabsås",
                Cost = 10
            },
            new Ingredient
            {
                IngredientId = 6,
                Name = "Räkor",
                Cost = 15
            },
            new Ingredient
            {
                IngredientId = 7,
                Name = "musslor",
                Cost = 15
            },
            new Ingredient
            {
                IngredientId = 8,
                Name = "kronärtskocka",
                Cost = 15
            },
            new Ingredient
            {
                IngredientId = 9,
                Name = "Kebab",
                Cost = 20
            },
            new Ingredient
            {
                IngredientId = 10,
                Name = "koriander",
                Cost = 20
            }
            };
        }

    }
}




