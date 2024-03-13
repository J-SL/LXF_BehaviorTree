# LXF_BehaviorTree
一个简易的行为树，虽然它简单，但是你可以用它来实现复杂的AI行为。


1.通过继承自Node，你可以在其中编写你想实现的一个行为。
2.通过继承自Selector，你可以编写你的一个判断逻辑，以运行你想要的子Node。
3.这颗树每层都为Node/Selector交错，Selector可以连接Node/UndertakeNode，建议使用继承自UndertakeNode的空Node来连接Selector。
4.LXF_MainEntrance是树的主入口，你可以继承它并为它编写逻辑。
5.通过继承自BaseTree，重写SetUpTree方法，初始化这棵树，如下图：
![Snipaste_2024-03-13_20-56-58](https://github.com/J-SL/LXF_BehaviorTree/assets/123278287/9c14019c-dda7-4454-b847-f8e842411cb1)

学习交流，QQ：2294421852
