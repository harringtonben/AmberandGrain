namespace AmberAndGrain.Controllers
{
    public class RecipesDto
    {
        public string Name { get; set; }
        public decimal PercentWheat { get; set; }
        public decimal PercentCorn { get; set; }
        public int BarrelAge { get; set; }
        public string BarrelMaterial { get; set; }
        public string Creator { get; set; }
    }
}