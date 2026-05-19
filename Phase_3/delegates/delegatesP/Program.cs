using System;
using System.Collections.Generic;

namespace AccessControlEngine
{
    class AccessContext
    {
        public string User;
        public int ClearanceLevel;
        public bool IsBlocked;
    }

    class AccessEngine
    {
        public event Action<AccessContext> OnAccessGranted;
        public event Action<AccessContext> OnAccessDenied;

        private readonly List<Predicate<AccessContext>> rules = new();
        private Func<AccessContext, AccessContext> transformer;

        public void AddRule(Predicate<AccessContext> rule)
        {
            rules.Add(rule);
        }

        public void SetTransformer(Func<AccessContext, AccessContext> transform)
        {
            transformer = transform;
        }

        public void Evaluate(AccessContext context)
        {
            if (transformer != null)
                context = transformer(context);

            foreach (var rule in rules)
            {
                if (!rule(context))
                {
                    OnAccessDenied?.Invoke(context);
                    return;
                }
            }

            OnAccessGranted?.Invoke(context);
        }
    }

    class AuditService
    {
        public void LogGrant(AccessContext context)
        {
            Console.WriteLine($"ACCESS GRANTED: {context.User}");
        }

        public void LogDeny(AccessContext context)
        {
            Console.WriteLine($"ACCESS DENIED: {context.User}");
        }
    }

    class Program
    {
        static void Main()
        {
            var engine = new AccessEngine();
            var audit = new AuditService();

            engine.OnAccessGranted += audit.LogGrant;
            engine.OnAccessDenied += audit.LogDeny;

            engine.AddRule(ctx => !ctx.IsBlocked);
            engine.AddRule(ctx => ctx.ClearanceLevel >= 3);

            engine.SetTransformer(ctx =>
            {
                ctx.ClearanceLevel += 1;
                return ctx;
            });

            var user = new AccessContext
            {
                User = "Anuska",
                ClearanceLevel = 2,
                IsBlocked = false
            };

            engine.Evaluate(user);
        }
    }
}
