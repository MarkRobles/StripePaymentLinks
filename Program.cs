using Stripe;

StripeConfiguration.ApiKey = "";


///Crea un producto y su precio
var optionsProduct = new ProductCreateOptions
{
    Name = "Product Name 1",
    Description = "Testin stripe payment links  ",
};
var serviceProduct = new ProductService();
Product product = serviceProduct.Create(optionsProduct);
Console.Write("Success! Here is your starter subscription product id: {0}\n", product.Id);

var optionsPrice = new PriceCreateOptions
{
    UnitAmount = (long)11,
    Currency = "MXN",

    Product = product.Id
};
var servicePrice = new PriceService();
Price price = servicePrice.Create(optionsPrice);
Console.Write("Success! Here is your starter subscription price id: {0}\n", price.Id);



//Crea un payment link
var options = new PaymentLinkCreateOptions
{
    LineItems = new List<PaymentLinkLineItemOptions>
    {
        new PaymentLinkLineItemOptions
        {
            Price = price.Id
,
            Quantity = 1,
        },
      
    },//REDIRECT AFTER COMPLETION
    AfterCompletion = new PaymentLinkAfterCompletionOptions
    {
        Type = "redirect",
        Redirect = new PaymentLinkAfterCompletionRedirectOptions
        {
            Url = "url you want to redirect",
        },
    },
};
var service = new PaymentLinkService();
PaymentLink obj =service.Create(options);
Console.WriteLine($"Link to pay {obj.Url}");
Console.ReadLine();

