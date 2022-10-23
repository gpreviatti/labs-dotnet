using Bogus;

namespace JsonCerverterxJsonSerializer;

public class PersonEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }


    public AddressEntity Address { get; set; }
    public List<AccountEntity> Accounts { get; set; }


    public static List<PersonEntity> GetPerson(int amountPeople, int amountAccounts = 1)
    {
        var _fakerPerson = new Faker<PersonEntity>("pt_BR")
            .StrictMode(false)
            .RuleFor(c => c.Id, f => f.Random.Uuid())
            .RuleFor(c => c.Name, f => f.Person.FirstName)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(c => c.Address, f => AddressEntity.GetAddress())
            .RuleFor(c => c.Accounts, f => AccountEntity.GetAccounts(amountAccounts));

        return _fakerPerson.Generate(amountPeople);
    }
}

public class AddressEntity
{
    public Guid Id { get; set; }
    public string State { get; set; }
    public string Neighbordhood { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }

    public static AddressEntity GetAddress()
    {
        var _fakerAccount = new Faker<AddressEntity>("pt_BR")
            .StrictMode(false)
            .RuleFor(c => c.Id, f => f.Random.Uuid())
            .RuleFor(c => c.State, f => f.Address.StreetAddress())
            .RuleFor(c => c.Country, f => f.Address.Country())
            .RuleFor(c => c.Neighbordhood, f => f.Address.FullAddress())
            .RuleFor(c => c.City, f => f.Address.City())
            .RuleFor(c => c.ZipCode, f => f.Address.ZipCode());

        return _fakerAccount.Generate();
    }
}

public class AccountEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string AccountType { get; set; }
    public Guid UserId { get; set; }

    public static List<AccountEntity> GetAccounts(int amount = 1)
    {
        var _fakerAccount = new Faker<AccountEntity>("pt_BR")
            .StrictMode(false)
            .RuleFor(c => c.Id, f => f.Random.Uuid())
            .RuleFor(c => c.Description, f => f.Finance.AccountName())
            .RuleFor(c => c.AccountType, f => f.Finance.TransactionType())
            .RuleFor(c => c.UserId, f => f.Random.Uuid());
        return _fakerAccount.Generate(amount);
    }
}
