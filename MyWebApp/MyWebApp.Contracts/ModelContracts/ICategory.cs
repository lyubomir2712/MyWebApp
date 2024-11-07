namespace Contracts.ModelContracts;

public interface ICategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
}