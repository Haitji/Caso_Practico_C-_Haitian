

namespace Bootcamp_store_backend.Application.Dtos
{
    public class CategoryDTO: IDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        
        public string? Description { get; set; }
        
        public byte[] Image { get; set; }
    }
}