using System;

namespace FreeRoamProject.Client
{
    // PRETTY OLD CLASS AIN'T IT.. ONE OF MY OLDEST.. PRIOR TO STATEBAGS.. 
    public enum DecorationType
    {
        Float = 1,
        Bool = 2,
        Int = 3,
        Time = 5
    }

    public static class EntityDecoration
    {
        internal static Type floatType = typeof(float);
        internal static Type boolType = typeof(bool);
        internal static Type intType = typeof(int);

        private static bool ExistOn(Entity entity, string propertyName) { return DecorExistOn(entity.Handle, propertyName); }

        public static bool HasDecor(this Entity ent, string propertyName) { return ExistOn(ent, propertyName); }

        public static void RegisterProperty(string propertyName, DecorationType type) { DecorRegister(propertyName, (int)type); }

        public static void LockProperties() { DecorRegisterLock(); }

        public static void Set(Entity entity, string propertyName, float floatValue) { DecorSetFloat(entity.Handle, propertyName, floatValue); }

        public static void Set(Entity entity, string propertyName, int intValue) { DecorSetInt(entity.Handle, propertyName, intValue); }

        public static void Set(Entity entity, string propertyName, bool boolValue) { DecorSetBool(entity.Handle, propertyName, boolValue); }

        public static void SetDecor(this Entity ent, string propertyName, float value) { Set(ent, propertyName, value); }

        public static void SetDecor(this Entity ent, string propertyName, int value) { Set(ent, propertyName, value); }

        public static void SetDecor(this Entity ent, string propertyName, bool value) { Set(ent, propertyName, value); }

        public static T Get<T>(Entity entity, string propertyName)
        {
            if (!ExistOn(entity, propertyName)) throw new EntityDecorationUnregisteredPropertyException();
            Type genericType = typeof(T);

            if (genericType == floatType) return (T)(object)DecorGetFloat(entity.Handle, propertyName);
            if (genericType == intType) return (T)(object)DecorGetInt(entity.Handle, propertyName);
            if (genericType == boolType) return (T)(object)DecorGetBool(entity.Handle, propertyName);

            throw new EntityDecorationUndefinedTypeException();
        }

        public static T GetDecor<T>(this Entity ent, string propertyName) { return Get<T>(ent, propertyName); }
    }

    public class EntityDecorationUnregisteredPropertyException : Exception
    {
    }

    public class EntityDecorationUndefinedTypeException : Exception
    {
    }
}