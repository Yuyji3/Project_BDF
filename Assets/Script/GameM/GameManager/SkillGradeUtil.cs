using UnityEngine;

public static class SkillGradeUtil
{
    public static SkillGrade GetRandomGrade(GradeProbabilityData data)
    {
        float f = data.probF;
        float d = data.probD;
        float c = data.probC;
        float b = data.probB;
        float a = data.probA;
        float s = data.probS;
        float ss = data.probSS;
        float sss = data.probSSS;

        float total = f + d + c + b + a + s + ss + sss;
        float roll = Random.Range(0f, total);

        if (roll < f) return SkillGrade.F;
        if (roll < f + d) return SkillGrade.D;
        if (roll < f + d + c) return SkillGrade.C;
        if (roll < f + d + c + b) return SkillGrade.B;
        if (roll < f + d + c + b + a) return SkillGrade.A;
        if (roll < f + d + c + b + a + s) return SkillGrade.S;
        if (roll < f + d + c + b + a + s + ss) return SkillGrade.SS;
        return SkillGrade.SSS;
    }
}
