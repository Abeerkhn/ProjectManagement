//namespace Softwash.Infrastructure.ExternalServices.Stripes
//{
//    public static class StripeHelper
//    {
//        static readonly StripeGateway gateway = new StripeGateway(StripeKey.ApiKey);

//        #region Create Customer
//        public static string CreateCustomer(string email)
//        {
//            var customer = gateway.Post(new CreateStripeCustomerWithToken
//            {
//                Email = email
//            });

//            return customer.Id;
//        }
//        public static StripeSearchResult<Customer> SearchCustomer(string email)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new CustomerSearchOptions
//            {
//                Query = $@"email:'{email}'",
//            };
//            var service = new CustomerService();
//            var obj = service.Search(options);

//            return obj;
//        }
//        #endregion

//        #region Card
//        public static Card CreateCard(StripeCard card)
//        {
//            var cardToken = gateway.Post(new CreateStripeToken
//            {
//                Card = card,
//            });

//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var options = new CardCreateOptions
//            {
//                Source = cardToken.Id
//            };
//            var service = new CardService();
//            var obj = service.Create(card.Customer, options);

//            return obj;
//        }
//        public static StripeReference DeleteCard(string customerId, string cardId)
//        {
//            var deletedRef = gateway.Delete(new DeleteStripeCustomerCard
//            {
//                CustomerId = customerId,
//                CardId = cardId
//            });

//            return deletedRef;
//        }
//        public static List<StripeCard> GetCustomerCard(string customerId)
//        {
//            var cards = gateway.Get(new GetStripeCustomerCards { CustomerId = customerId });
//            return cards.Data;
//        }

//        public static void UpdateCardSource(string customerId, string cardId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new CustomerUpdateOptions
//            {
//                DefaultSource = cardId
//            };
//            var service = new CustomerService();
//            service.Update(customerId, options);
//        }
//        #endregion

//        #region Connected Account
//        public static string CreateConnectAccountStripe(string companyName, string vatNumber, string license, string email, string countryname)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            //AccountCompanyOptions companyAccount = new AccountCompanyOptions
//            //{
//            //    Name = companyName,
//            //    VatId = vatNumber,
//            //    RegistrationNumber = license
//            //};

//            var options = new AccountCreateOptions
//            {
//                Type = "standard",
//                Email = email,
//                //Company = companyAccount,
//                BusinessType = "company",
//                Country = countryname,
//            };

//            var service = new AccountService();
//            var response = service.Create(options);
//            return response.Id;
//        }
//        public static string CreateAccountLink(string stripeId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var options = new AccountLinkCreateOptions
//            {
//                Account = stripeId,
//                RefreshUrl = StripeConnectedAccount.RefreshUrl,
//                ReturnUrl = StripeConnectedAccount.ReturnUrl,
//                Type = "account_onboarding",
//            };
//            var service = new AccountLinkService();
//            var response = service.Create(options);
//            return response.Url;
//        }
//        public static bool OnBoardingProcessCompleted(string stripeId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var service = new AccountService();
//            var acct = service.Get(stripeId);
//            return acct.DetailsSubmitted;
//        }

//        #endregion 

//        #region Product
//        public static string CreateProduct(ProductDTO dto)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var obj = new ProductCreateOptions
//            {
//                Name = dto.Name,
//                Description = dto.Description,
//            };
//            var service = new ProductService();
//            var response = service.Create(obj);
//            return response.Id;
//        }
//        public async static Task<string> UpdateProduct(string id, string name)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var obj = new ProductUpdateOptions
//            {
//                Name = name
//            };
//            var service = new ProductService();
//            var response = await service.UpdateAsync(id, obj);
//            return response.Id;
//        }

//        public static List<Product> GetProductList()
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var options = new ProductListOptions
//            {
//                Limit = 2,
//            };
//            var service = new ProductService();
//            var response = service.List(
//              options);
//            return response.Data;
//        }

//        public static void DeleteProduct(string id)
//        {
//            try
//            {
//                StripeConfiguration.ApiKey = StripeKey.ApiKey;
//                var service = new ProductService();
//                service.Delete(id);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//        #endregion

//        #region Price
//        public static string CreatePrice(PriceDTO dto)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var obj = new PriceCreateOptions
//            {
//                Product = dto.ProductId,
//                UnitAmountDecimal = dto.AmountDecimal * 100,
//                Currency = dto.Currency,

//                //Recurring = new PriceRecurringOptions
//                //{
//                //    Interval = dto.Interval,
//                //}
//            };

//            var service = new PriceService();
//            var response = service.Create(obj);

//            return response.Id;
//        }

//        #endregion

//        #region Plan
//        public async static Task<string> CreatePlan(PlanStripeDTO dto)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var obj = new PlanCreateOptions
//            {
//                Product = dto.ProductId,
//                AmountDecimal = dto.AmountDecimal * 100,
//                Currency = dto.Currency,
//                Interval = dto.Interval
//            };

//            var service = new PlanService();
//            var response = await service.CreateAsync(obj);
//            return response.Id;
//        }
//        #endregion

//        #region Plan
//        public static PaymentIntent PaymentIndent(string id)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var options = new PaymentIntentCreateOptions
//            {
//                Amount = 2000,
//                Currency = "usd",
//                Customer = id,
//                Confirm = true,
//                ReturnUrl = "https://dashboard.stripe.com",
//                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
//                {
//                    Enabled = true,
//                },
//            };

//            var service = new PaymentIntentService();
//            var response = service.Create(options);
//            return response;
//        }
//        #endregion

//        #region Subscription
//        public static Subscription CreateSubscription(string customerId, string priceId, string couponId = null)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new SubscriptionCreateOptions
//            {
//                Customer = customerId,
//                Items = new List<SubscriptionItemOptions>
//                {
//                    new SubscriptionItemOptions { Price = priceId },
//                },
//                //Expand = new List<string> { "latest_invoice.payment_intent" },
//                //TransferData = new SubscriptionTransferDataOptions
//                //{
//                //    Destination = AdminStripeAccount.MembershipAccount,
//                //},
//                //Coupon = couponId
//            };

//            var service = new SubscriptionService();
//            return service.Create(options);


//            //var subscription = gateway.Post(new SubscribeStripeCustomer
//            //{
//            //    CustomerId = customerId,
//            //    Plan = priceId,
//            //    Quantity = 1,
//            //    Coupon = couponId,
//            //});

//            //return subscription;
//        }
//        public static void CancelSubscription(string subscriptionId)
//        {
//            var retrievedSubscription = gateway.Get(new GetStripeSubscription
//            {
//                SubscriptionId = subscriptionId
//            });

//            if (retrievedSubscription.Status != StripeSubscriptionStatus.Canceled)
//            {
//                var cancelled = gateway.Delete(new CancelStripeSubscription
//                {
//                    SubscriptionId = subscriptionId,
//                    InvoiceNow = true,
//                    Prorate = true,
//                });
//            }

//        }
//        public static bool CheckSubscriptionExist(string subscriptionId)
//        {
//            var retrievedSubscription = gateway.Get(new GetStripeSubscription
//            {
//                SubscriptionId = subscriptionId
//            });

//            if (retrievedSubscription.Status != StripeSubscriptionStatus.Canceled)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public static Subscription UpdateSubscription(string subscriptionId, string priceId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var service = new SubscriptionService();
//            Subscription subscription = service.Get(subscriptionId);

//            var items = new List<SubscriptionItemOptions> {
//                new SubscriptionItemOptions {
//                    Id = subscription.Items.Data[0].Id,
//                    Price = priceId,
//                },
//            };

//            var options = new SubscriptionUpdateOptions
//            {
//                CancelAtPeriodEnd = false,
//                ProrationBehavior = "none",
//                Items = items,
//                //TransferData = new SubscriptionTransferDataOptions
//                //{
//                //    Destination = AdminStripeAccount.MembershipAccount,
//                //},
//            };
//            subscription = service.Update(subscriptionId, options);

//            return subscription;
//        }
//        public static Subscription GetSubscription(string subscriptionId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var service = new SubscriptionService();
//            Subscription subscription = service.Get(subscriptionId);

//            return subscription;
//        }

//        #endregion

//        #region Balance Transaction
//        public static BalanceTransaction GetBalanceTransaction(string balanceTransactionId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var service = new BalanceTransactionService();
//            return service.Get(balanceTransactionId);
//        }

//        #endregion

//        #region Coupon
//        public static Coupon CreateCoupon(CouponStripeDTO coupon)
//        {

//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            CouponCreateOptions options;

//            string duration;

//            if (coupon.DurationInMonths is null)
//                duration = "once";
//            else
//                duration = "repeating";

//            if (coupon.Amount is null)
//            {
//                options = new CouponCreateOptions
//                {
//                    Id = coupon.Id,
//                    Duration = duration,
//                    DurationInMonths = coupon.DurationInMonths,
//                    MaxRedemptions = 1,
//                    PercentOff = coupon.Percentage,
//                    Currency = "usd",

//                };
//            }

//            else
//            {
//                var amount = coupon.Amount * 100;
//                options = new CouponCreateOptions
//                {
//                    Id = coupon.Id,
//                    Duration = duration,
//                    DurationInMonths = coupon.DurationInMonths,
//                    MaxRedemptions = 1,
//                    AmountOff = amount,
//                    Currency = "usd",

//                };
//            }

//            var service = new CouponService();
//            var response = service.Create(options);

//            return response;
//        }

//        #endregion

//        #region Charge
//        public static Charge CreateChargeWithCustomerId(long amount, string customerId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new ChargeCreateOptions
//            {
//                Amount = amount * 100,
//                Currency = "usd",
//                Customer = customerId
//            };
//            var service = new ChargeService();
//            var charge = service.Create(options);
//            return charge;
//        }
//        public static Charge GetChargeDetail(string chargeId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var service = new ChargeService();
//            var charge = service.Get(chargeId);
//            return charge;
//        }
//        public static List<Charge> GetChargeIdListWithCustomerId(string customerId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var options = new ChargeListOptions
//            {
//                Customer = customerId
//            };

//            var service = new ChargeService();
//            StripeList<Charge> charges = service.List(options);
//            return charges.Data;
//        }
//        public static Refund FullRefundCharge(string chargeId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new RefundCreateOptions
//            {
//                Charge = chargeId,
//            };

//            var service = new RefundService();
//            var refund = service.Create(options);
//            return refund;
//        }
//        public static Refund PartiallyRefundCharge(long amount, string chargeId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new RefundCreateOptions
//            {
//                Charge = chargeId,
//                Amount = amount * 100,
//            };

//            var service = new RefundService();
//            var refund = service.Create(options);
//            return refund;
//        }

//        #endregion

//        #region Transfer
//        public static string TransferAmountToConnectedAccount(double amount, string chargeId, string conectedAccountId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new TransferCreateOptions
//            {
//                Amount = (long?)(amount * 100),
//                Currency = "usd",
//                SourceTransaction = chargeId,
//                Destination = conectedAccountId
//            };

//            var service = new TransferService();
//            var Transfer = service.Create(options);
//            return Transfer.Id;
//        }
//        public static string RefundTransferAmountFromConnectedAccount(long amount, string transferId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new TransferReversalCreateOptions
//            {
//                Amount = amount * 100,
//            };

//            var service = new TransferReversalService();
//            var reversal = service.Create(transferId, options);
//            return reversal.Id;
//        }
//        #endregion

//        #region Invoice

//        public static Invoice CreateInvoice(string customerId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new InvoiceCreateOptions
//            {
//                Customer = customerId,
//                AutoAdvance = true
//            };
//            var service = new InvoiceService();
//            return service.Create(options);
//        }
//        public static List<Invoice> GetInvoiceListByCustomerId(string customerId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new InvoiceListOptions
//            {
//                Customer = customerId,
//            };
//            var service = new InvoiceService();
//            var response = service.List(
//              options);
//            return response.Data;
//        }
//        public static Invoice Upcoming(string customerId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var options = new UpcomingInvoiceOptions
//            {
//                Customer = customerId,
//            };
//            var service = new InvoiceService();
//            return service.Upcoming(options);
//        }
//        public static void PayInvoice(string id)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;
//            var service = new InvoiceService();
//            service.Pay(id);
//        }

//        #endregion

//        #region Invoice Item

//        public static string CreateInvoiceItem(string customerId, string priceId)
//        {
//            StripeConfiguration.ApiKey = StripeKey.ApiKey;

//            var options = new InvoiceItemCreateOptions
//            {
//                Customer = customerId,
//                Price = priceId,

//                Period = new InvoiceItemPeriodOptions()
//                {
//                    Start = DateTime.UtcNow,
//                    End = DateTime.UtcNow,
//                }
//            };

//            var service = new InvoiceItemService();
//            var response = service.Create(options);

//            return response.Invoice.Id;
//        }
//        #endregion

//    }
//}
