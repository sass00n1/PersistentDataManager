# PersistentDataManager
## 这是什么？
这是一个适用于Unity的数据持久化方案。它的优点是：
* 集中保存所有继承了接口的成员，任何想要被持久化的对象只需继承接口即可。
* 这些成员可以进行自定义设置，例如仅可读，仅可写，可读可写。
![图片](https://user-images.githubusercontent.com/41114110/133961037-411f568a-8619-47d8-8e11-d79cda8c63d4.png)
## 示例说明
1. PlayerInput类是主角的Mono类，存储着分数，所以它是我们要数据持久化的成员，只需将他继承IDataPersister接口并实现接口中的方法，例如属于此类的特定保存行为。
2. 在PlayerInput类的OnEnable与OnDisable，分别将自身注册和注销到PersistentDataManager。
3. 当玩家触碰石柱进入下一关之际，在场景的转换方法体内进行相关的保存操作，这一操作会保存所有继承IDataPersister接口并注册的成员。
4. 这时载入第二关完毕后，PlayerInput类会因为OnEnable事件再次注册进管理器，随后PersistentDataManager进行恢复数据工作，所有注册进来的成员将恢复数据，完成游戏的跨场景存储功能。
## 如何使用
Core文件夹下的PersistentDataManager与IDataPersister是本库的核心类，只需将这两个移到你的项目即可。
## 引用
* Brackeys/[2D-Character-Controller](https://github.com/Brackeys/2D-Character-Controller)
* Unity-Technologies/2DKit
