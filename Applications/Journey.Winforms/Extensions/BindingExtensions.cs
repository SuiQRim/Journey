using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Journey.Applications.JourneyWinforms.Extensions
{
    /// <summary>
    /// Класс с расширениями для биндинга данных в WinForms
    /// </summary>
    public static class BindingExtensions
    {
        /// <summary>
        /// Добавляет биндинг данных с возможностью валидации через ErrorProvider
        /// </summary>
        /// <typeparam name="TControl">Тип контрола</typeparam>
        /// <typeparam name="TSource">Тип источника данных</typeparam>
        /// <param name="control">Контрол, к которому применяется биндинг</param>
        /// <param name="targetProperty">Свойство контрола для привязки</param>
        /// <param name="source">Источник данных</param>
        /// <param name="sourceProperty">Свойство источника данных</param>
        /// <param name="errorProvider">Компонент для отображения ошибок валидации</param>
        public static void AddBinding<TControl, TSource>(
            this TControl control,
            Expression<Func<TControl, object>> targetProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var sourcePropertyName = GetMemberName(sourceProperty);

            control.DataBindings.Add(
                GetMemberName(targetProperty),
                source,
                sourcePropertyName,
                formattingEnabled: false,
                DataSourceUpdateMode.OnPropertyChanged
            );

            if (errorProvider != null)
            {
                control.Validating += (_, e) =>
                {
                    var property = source.GetType().GetProperty(sourcePropertyName);
                    var value = property.GetValue(source);

                    var context = new ValidationContext(source)
                    {
                        MemberName = sourcePropertyName
                    };

                    var results = new List<ValidationResult>();

                    errorProvider.SetError(control, null);

                    if (!Validator.TryValidateProperty(value, context, results))
                    {
                        foreach (var error in results)
                        {
                            errorProvider.SetError(control, error.ErrorMessage);
                        }

                        e.Cancel = true;
                    }
                };
            }
        }

        private static string GetMemberName<T>(Expression<Func<T, object>> expression)
        {
            if (expression.Body is UnaryExpression unary)
            {
                var member = (MemberExpression)unary.Operand;
                return member.Member.Name;
            }

            var memExp = (MemberExpression)expression.Body;
            return memExp.Member.Name;
        }
    }
}
