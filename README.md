# Shiny Flakes

Beschreibung...

## Team

* A
* B

### asdasdas

x **Fett** ADASDASD *Kursiv* asdads ** sadfaddasdsa ***FETTKursiv***

#### asdasdsddas

x

##### asdasdsadsadasdasd

1. Punkt 1
1. Punkt 2
1. Punkt 3
1. Punkt 4

## C# Example

```C#
SchoolClass scB401 = new SchoolClass() { RoomNumber = "B4.01" };
MyList<SchoolClass> schoolClasses = new MyList<SchoolClass>()
{
    scB401,
    new SchoolClass() { RoomNumber = "B4.02" },
    new SchoolClass() { RoomNumber = "B4.02" },
    new SchoolClass() { RoomNumber = "B4.03",
        Students = new List<Student>()
        {
            new Student() { FirstName="Martin", Lastname="Schrutek" },
            new Student() { FirstName="Martin1", Lastname="Schrutek1" },
            new Student() { FirstName="Martin2", Lastname="Schrutek2" },
            new Student() { FirstName="Martin3", Lastname="Schrutek3" },
            new Student() { FirstName="Martin4", Lastname="Schrutek4" },
        }
    }
};
```

## HTML Example

```html
<h1>Welcome!!</h1>
```

## Domain Model

```plantuml
@startuml

abstract class Person {
    + Id: int
    + Guid: Guid
    + Gender: Genders
    + FirstName: string
    + LastName: string
    + PhoneNumber: PhoneNumber
    + EMail: EMail
}

entity Customer {
    + Username: string
    + RegistrationDateTime: DateTime
    + Address: Address
}

entity Employee {
    + EmployeeId: int
}

entity Shop {
    + Id: int
    + Name: string
    + CompanySuffix: string
    + Address: Address
    + PhoneNumber: PhoneNumber
    + EMail: Set<EMail>
}

entity Category {
    + Id: int
    + Name: string
}

entity Product {
    + Id: int
    + Name: string
    + Description: string
    + ExpiryDate: DateOnly?
}

entity ShoppingCart {
    + Id: int
    + Guid: Guid
    + Status: ShoppingCartStates
    + ShoppingCartItems: List<ShoppingCartItem>
}

entity ShoppingCartProduct {
    + Id: int
    + Guid: Guid
    + Procuct: Product
    + Pieces: int
}

enum ShoppingCartStates {
    Active
    Payed
    Sent
    Delivered
    Unknown = 99
}

enum Genders {
    Male
    Female
    Diverse
}

class Address << (V,#FF7700) Embeddable >> {
    Street: string
    HouseNumber: string
    City: string
    Zip: string
}

class PhoneNumber << (V,#FF7700) Embeddable >> {
    Prefix: string
    Number: string
}

class EMail << (V,#FF7700) Embeddable >> {
    Address: string
}

Shop "1" o-- "*" Category : < ownes one
Category "0..1" o-- "1..n" Product  : < ownes one or zero
Customer .. Genders
Customer "1" o-- "1..n" ShoppingCart : < ownes one
ShoppingCart "1" *-- "1..n" ShoppingCartProduct
Product "1"  *-- "1..n" ShoppingCartProduct
ShoppingCart .. ShoppingCartStates
Customer -up- Address
Customer -up- PhoneNumber
Customer -- EMail
Shop -- Address
Shop -- PhoneNumber
Shop -- EMail

Customer --|> Person
Employee --|> Person

hide empty members

@enduml
```

xxxx