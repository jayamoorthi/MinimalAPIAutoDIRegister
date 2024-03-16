

To practical implementation following items need to Installation in your system. 


•	Visual Studio 2022 
•	.NET 6
•	ASP NET 6.0 Runtime
•	SqlServer Database
•	Apache Kafka 
•	Java Runtime Environment (JRE)
•	Docker Desktop
•	MediatR
•	AutoMapper
•	FluentValidation
•	EF Core
•	CQRS, Repository Pattern,


Fluent Validation: 
It’s used for strongly typed validation rules in .net library. 
  There are two types of validators
1.	Build-in Validator
2.	Custom Validator

Git source : https://github.com/jayamoorthi/MinimalAPIAutoDIRegister/commit/c287f134165fc92adbeb7454ac37240fc51fbdb6
Build-in Validator.
 It already has been exists some build in validation methods like, NotNull(), NotEmpty(), EmailAddresses(), NotEqual(), Equal(), Length(),MaxLength(),MinLength(),LessThan(),LessThanOrEqualTo(),


RuleFor(user => user.Email).EmailAddress().WithMessage("Enter valid email address");
RuleFor(user => user.LastName).MaximumLength(100)

RuleFor(user => user.FirstName).MinimumLength(10)
Custom Validator: 
Create our own custom validator class and inherit AbstractValidator<Model> class on it, then write our own custom logic which is need to validate in our model. 
![image](https://github.com/jayamoorthi/MinimalAPIAutoDIRegister/assets/41425769/b240f0d6-dc97-4aa1-a19a-3d9a336cb0bd)

 
Rule for the model need to validates. 
 
![image](https://github.com/jayamoorthi/MinimalAPIAutoDIRegister/assets/41425769/1cea25dc-edc0-4e58-bc8e-573b056b6f7a)




DI register all the custom validator in service using extension method 
Method 1:  registering in service collection
 
![image](https://github.com/jayamoorthi/MinimalAPIAutoDIRegister/assets/41425769/a89c9b83-46ff-408b-b925-c6b90be38b5f)

Method 2:  loading all DI from assembly in using AddValidatorFromAssesmbly()

![image](https://github.com/jayamoorthi/MinimalAPIAutoDIRegister/assets/41425769/4a3dfc6b-2096-477d-b250-6e58d19c8e57)

 

 How do validate our custom validator? 
 We can inject our custom validator in our userservice class and call Validate(), if rule is success then Isvalid is true,  else return errors collection of each property. 

  ![image](https://github.com/jayamoorthi/MinimalAPIAutoDIRegister/assets/41425769/cf9b0cc3-f416-4593-bb8f-815f33def3fe)

