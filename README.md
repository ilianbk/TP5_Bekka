# TP5_Bekka
Part 2 Test : What is the benefit of adding tests here?
The benefit of having multiples test is that it allows us to try each importants aspects of the code. It helps to fully undertsand the basic code and test if everything is working. The more test we have, the better we understand our code. 

Then, find at least 3 ways to expand this code to add more functionalities. Explain how you would  carry  on  with  your  implementation  of  the  code.  Thread  carefully,  this  is  harder  than you think it is.Scalability is key.You don’t need to code these, but you should explain in detail what you would do.

The first way is to add a new item. We could create a new method that allows the creation of a new item by getting the Item.cs getter and setter. This method will be callable in the main and it will easily facilitate the creation of new object. 
The second is related to the first one. We could create another method to change item properties such as specific description of it. As we approach SellIn date, the item color might change (for example), or an item could evoluate to a rarest one, with a higher quality. this method woul be call ItemChange() ande will be available on a specific class.
Last, we could have the possibility to buy items instead of creating ones. We could create a list were on sale items are available and the Gilded could buy them by calling the item wanted. Item owned by the Gilded can also be sold and then be deleted from the list of the project and stored to this new list, with a specific price. For this, we should add a virtual budgect that allows the Gilded to buy them. Thus, the amount won't be unlimited, the Gilded might have to slel items in order to buy rarest ones. 

PS : ApprovalTest didn't passes because I wasn't able to fix it (didn't understand what the test was doing).
