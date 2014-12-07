using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

public class UsefulStuff {
	public static void ResetStatics(Type type) {
		MemberInfo[] members = type.GetMembers();
		Type defaultValues = Type.GetType(type.Name + "_DefaultValues");
		if (defaultValues != null) {
			foreach (MemberInfo member in members) {
				if (member.MemberType == MemberTypes.Field) {
					FieldInfo field = (FieldInfo)member;
					FieldInfo defaultValueField = defaultValues.GetField(field.Name);
					if (field != null && defaultValueField != null && field.IsPublic && field.IsStatic && defaultValueField.IsStatic) {
						field.SetValue(null, defaultValueField.GetValue(null));
					}
				}
			}
		}
	}
}
public struct BaseTimer_DefaultValues{
	public static float current = 100.0f;
}
