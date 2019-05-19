# Zupa Developer Test

This test is used as part of the recruitment process for developers looking to join Zupa. We would expect candidates to need a couple of hours to complete the requirements, however there is no fixed time limit and you may spend as much time as you wish.

Your code should be written in a way that shows you have a good understanding of software design patterns, SOLID principles and development best practices. You should use the code contained within this repository as a base for your solution and adapt it as required. When you are finished please submit a link to your repository (GitHub, GitLab, BitBucket, Azure DevOps) or provide us with the source code.

If you have any questions about the test, please ask.

## Test

The project provided here is a simple implementation of a shopping cart, it allows the user to view the items available for purchase, add those items to a basket and place an order. The project uses ASP.NET Core, MVC, HTML, bootstrap and JavaScript. We want you to extend this shopping cart to allow users to enter promotional codes which will reduce the total of their order. Each code can only ever be used once and only one code per order can be used. 

### Acceptance Criteria

* GIVEN an item has been added to the basket WHEN placing an order THEN display the correct total for the order
* GIVEN the promo code 'discount10' WHEN placing an order AND the code has not been used before THEN reduce the total by 10%
* GIVEN the promo code 'discount50' WHEN placing an order AND the code has not been used before THEN reduce the total by 50%
* GIVEN a promo code has been used before WHEN placing an order AND attempting to use the same code again THEN warn the user the code is invalid AND do not place the order
