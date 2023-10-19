﻿using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Utilities.WPF.Controls
{
    /// <summary>
    /// A control that behaves exactly like a normal textblock, 
    /// with one added benefit of ability to select and copy the text in the textBlock.
    /// Taken from https://stackoverflow.com/a/45627524/16765400.
    /// </summary>
    public class SelectableTextBlock : TextBlock
    {
        static SelectableTextBlock()
        {
            FocusableProperty.OverrideMetadata(typeof(SelectableTextBlock), new FrameworkPropertyMetadata(true));
            TextEditorWrapper.RegisterCommandHandlers(typeof(SelectableTextBlock), true, true, true);

            // remove the focus rectangle around the control
            FocusVisualStyleProperty.OverrideMetadata(typeof(SelectableTextBlock), new FrameworkPropertyMetadata((object)null));
        }

        private readonly TextEditorWrapper _editor;

        /// <summary>
        /// The default constructor.
        /// </summary>
        public SelectableTextBlock()
        {
            _editor = TextEditorWrapper.CreateFor(this);

            this.Loaded += (sender, args) =>
            {
                this.Dispatcher.UnhandledException -= Dispatcher_UnhandledException;
                this.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            };
            this.Unloaded += (sender, args) =>
            {
                this.Dispatcher.UnhandledException -= Dispatcher_UnhandledException;
            };
        }

        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (!string.IsNullOrEmpty(e?.Exception?.StackTrace))
            {
                if (e.Exception.StackTrace.Contains("System.Windows.Controls.TextBlock.GetTextPositionFromDistance"))
                {
                    e.Handled = true;
                }
            }
        }
    }

    /// <summary>
    /// A wrapper for the selectable textbblock.
    /// </summary>
    public class TextEditorWrapper
    {
        private static readonly Type TextEditorType = Type.GetType("System.Windows.Documents.TextEditor, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        private static readonly PropertyInfo IsReadOnlyProp = TextEditorType.GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly PropertyInfo TextViewProp = TextEditorType.GetProperty("TextView", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly MethodInfo RegisterMethod = TextEditorType.GetMethod("RegisterCommandHandlers",
            BindingFlags.Static | BindingFlags.NonPublic, null, new[] { typeof(Type), typeof(bool), typeof(bool), typeof(bool) }, null);

        private static readonly Type TextContainerType = Type.GetType("System.Windows.Documents.ITextContainer, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        private static readonly PropertyInfo TextContainerTextViewProp = TextContainerType.GetProperty("TextView");

        private static readonly PropertyInfo TextContainerProp = typeof(TextBlock).GetProperty("TextContainer", BindingFlags.Instance | BindingFlags.NonPublic);

        /// <summary>
        /// Registers command handlers.
        /// </summary>
        public static void RegisterCommandHandlers(Type controlType, bool acceptsRichContent, bool readOnly, bool registerEventListeners)
        {
            RegisterMethod.Invoke(null, new object[] { controlType, acceptsRichContent, readOnly, registerEventListeners });
        }

        /// <summary>
        /// Creates a wrapper for the given textblock.
        /// </summary>
        public static TextEditorWrapper CreateFor(TextBlock tb)
        {
            var textContainer = TextContainerProp.GetValue(tb);

            var editor = new TextEditorWrapper(textContainer, tb, false);
            IsReadOnlyProp.SetValue(editor._editor, true);
            TextViewProp.SetValue(editor._editor, TextContainerTextViewProp.GetValue(textContainer));

            return editor;
        }

        private readonly object _editor;

        /// <summary>
        /// Creates a new text editor wrapper.
        /// </summary>
        public TextEditorWrapper(object textContainer, FrameworkElement uiScope, bool isUndoEnabled)
        {
            _editor = Activator.CreateInstance(TextEditorType, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance,
                null, new[] { textContainer, uiScope, isUndoEnabled }, null);
        }
    }
}
