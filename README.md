# LXF_BehaviorTree
一个简易的行为树，虽然它简单，但是你可以用它来实现复杂的AI行为。


1.通过继承自Node，你可以在其中编写你想实现的一个行为。
2.通过继承自Selector，你可以编写你的一个判断逻辑，以运行你想要的子Node。
3.这颗树每层都为Node/Selector交错，Selector可以连接Node/UndertakeNode，建议使用继承自UndertakeNode的空Node来连接Selector。
4.LXF_MainEntrance是树的主入口，你可以继承它并为它编写逻辑。
5.通过继承自BaseTree，重写SetUpTree方法，初始化这棵树，如下图：
![Snipaste_2024-03-13_20-56-58](https://github.com/J-SL/LXF_BehaviorTree/assets/123278287/9c14019c-dda7-4454-b847-f8e842411cb1)

学习交流，QQ：2294421852



------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
2024.3.26更新：
通过继承自LXF_Node，你可以在其中编写你想实现的一个行为,除此之外，你可以在执行这个行为和退出这个行为时执行一次你想要的设置：
![Snipaste_2024-03-26_09-07-42](https://github.com/J-SL/LXF_BehaviorTree/assets/123278287/eee0c817-1858-45af-a04f-0a6512ec3fe1)
你也可以通过GetMainEntrance和GetAimSelector来找到主节点或Selector节点。


通过继承自LXF_Selector，你可以编写你的一个判断逻辑，以运行你想要的子Node，行为树会自动化检测当前状态条件，你只需关心Selector下的子Node即可，而无需手动跳转。
同样的，LXF_Selector也添加了类似的初始化操作：
![Snipaste_2024-03-26_09-14-25](https://github.com/J-SL/LXF_BehaviorTree/assets/123278287/80d0c518-144d-4379-9ecd-3cc2bece0826)


通过继承自LXF_MainEntrance编写你的主节点，这个节点意在链接你的其它节点，同时你可以通过它的TryGetAnyNode方法来获得行为树的任意子节点。
初始化这棵树需要添加这颗树本身，以建立与实际物体的联系，通常在SetUpTree（LXF_Tree中的方法）中传入this即可：
![Snipaste_2024-03-26_09-19-57](https://github.com/J-SL/LXF_BehaviorTree/assets/123278287/4e71f0b3-50a4-4a03-9283-a31c25087a88)


LXF_UndertakeNode是一个特殊的LXF_Node，它只做一件事，如图：
![Snipaste_2024-03-26_09-24-52](https://github.com/J-SL/LXF_BehaviorTree/assets/123278287/0a40448f-efb4-4267-88cd-a9cddb578f16)
我已经提供好了9个内置的LXF_UndertakeNode，可以直接使用。



通过继承自LXF_Tree来编写你独一无二的行为树，而你只需要做一件事，就是重写SetUpTree方法！
这可能会有些复杂，但是你只需要做一次，如下图是我基于这颗行为树编写的一个守卫者的ai：
![Snipaste_2024-03-26_09-27-51](https://github.com/J-SL/LXF_BehaviorTree/assets/123278287/1006906b-1a6a-4c70-a235-d4b8f93f968e)
通常在SetUpTree之前利用树状图会使思路明了，以下是守卫者ai的行为树状图：
![Snipaste_2024-03-26_09-29-10](https://github.com/J-SL/LXF_BehaviorTree/assets/123278287/748d28a3-6785-455e-b9c1-14936a45ece6)


好了，今天的介绍就到这里。
本人QQ：2294421852
欢迎交流学习。






