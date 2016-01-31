namespace Entitas {
    public partial class Entity {
        public MyBoolComponent myBool { get { return (MyBoolComponent)GetComponent(ComponentIds.MyBool); } }

        public bool hasMyBool { get { return HasComponent(ComponentIds.MyBool); } }

        public Entity AddMyBool(bool newMyBool) {
            var componentPool = GetComponentPool(ComponentIds.MyBool);
            var component = (MyBoolComponent)(componentPool.Count > 0 ? componentPool.Pop() : new MyBoolComponent());
            component.myBool = newMyBool;
            return AddComponent(ComponentIds.MyBool, component);
        }

        public Entity ReplaceMyBool(bool newMyBool) {
            var componentPool = GetComponentPool(ComponentIds.MyBool);
            var component = (MyBoolComponent)(componentPool.Count > 0 ? componentPool.Pop() : new MyBoolComponent());
            component.myBool = newMyBool;
            ReplaceComponent(ComponentIds.MyBool, component);
            return this;
        }

        public Entity RemoveMyBool() {
            return RemoveComponent(ComponentIds.MyBool);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMyBool;

        public static IMatcher MyBool {
            get {
                if (_matcherMyBool == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.MyBool);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherMyBool = matcher;
                }

                return _matcherMyBool;
            }
        }
    }
}