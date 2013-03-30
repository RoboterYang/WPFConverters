using System;
using Kent.Boogaart.Converters.Expressions.Nodes;
using Xunit;

namespace Kent.Boogaart.Converters.UnitTests.Expressions.Nodes
{
    public sealed class InequalityNodeTest : WideningBinaryNodeTestBase
    {
        private InequalityNode inequalityNode;

        protected override void SetUpCore()
        {
            base.SetUpCore();
            this.inequalityNode = new InequalityNode(new ConstantNode<int>(0), new ConstantNode<int>(0));
        }

        [Fact]
        public void OperatorSymbols_ShouldYieldCorrectOperatorSymbols()
        {
            Assert.Equal("!=", GetPrivateMemberValue<string>(this.inequalityNode, "OperatorSymbols"));
        }

        [Fact]
        public void DoString_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoString", "abc", "abc"));
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoString", null, null));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoString", "abc", null));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoString", "abc", "abcd"));
        }

        [Fact]
        public void DoBoolean_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoBoolean", true, true));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoBoolean", true, false));
        }

        [Fact]
        public void DoByte_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoByte", (byte)1, (byte)1));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoByte", (byte)1, (byte)2));
        }

        [Fact]
        public void DoInt16_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoInt16", (short)1, (short)1));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoInt16", (short)1, (short)2));
        }

        [Fact]
        public void DoInt32_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoInt32", 1, 1));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoInt32", 1, 2));
        }

        [Fact]
        public void DoInt64_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoInt64", 1L, 1L));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoInt64", 1L, 2L));
        }

        [Fact]
        public void DoSingle_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoSingle", 1f, 1f));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoSingle", 1f, 2f));
        }

        [Fact]
        public void DoDouble_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoDouble", 1d, 1d));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoDouble", 1d, 2d));
        }

        [Fact]
        public void DoDecimal_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoDecimal", 1m, 1m));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoDecimal", 1m, 2m));
        }

        [Fact]
        public void DoValueType_ShouldDoComparison()
        {
            var value1 = DateTime.UtcNow;
            var value2 = value1.Add(TimeSpan.FromDays(1));
            var value3 = value1;

            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoValueType", value1, value3));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoValueType", value1, value2));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoValueType", value3, value2));
        }

        [Fact]
        public void DoReferenceType_ShouldDoComparison()
        {
            Assert.False(InvokeDoMethod<bool>(this.inequalityNode, "DoReferenceType", this, this));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoReferenceType", this, this.inequalityNode));
            Assert.True(InvokeDoMethod<bool>(this.inequalityNode, "DoReferenceType", this.inequalityNode, new InequalityNode(new ConstantNode<int>(0), new ConstantNode<int>(0))));
        }
    }
}