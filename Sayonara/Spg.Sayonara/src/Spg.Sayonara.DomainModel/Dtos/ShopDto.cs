namespace Spg.Sayonara.DomainModel.Dtos
{
    public record ShopDto(
        string Name, 
        string? CompanySuffix, 
        AddressDto? Address, 
        PhoneNumberDto PhoneNumber, 
        List<CategoryDto> Categories);
}
