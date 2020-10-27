using System;

namespace Utility.Interop.Native
{
    public class BHID
    {
        public static readonly Guid SFObject                    = new Guid("3981e224-f559-11d3-8e3a-00c04f6837d5");
        public static readonly Guid SFUIObject                  = new Guid("3981e225-f559-11d3-8e3a-00c04f6837d5");
        public static readonly Guid SFViewObject                = new Guid("3981e226-f559-11d3-8e3a-00c04f6837d5");
        public static readonly Guid Storage                     = new Guid("3981e227-f559-11d3-8e3a-00c04f6837d5");
        public static readonly Guid Stream                      = new Guid("1CEBB3AB-7C10-499a-A417-92CA16C4CB83");
        public static readonly Guid RandomAccessStream          = new Guid("f16fc93b-77ae-4cfe-bda7-a866eea6878d");
        public static readonly Guid LinkTargetItem              = new Guid("3981e228-f559-11d3-8e3a-00c04f6837d5");
        public static readonly Guid StorageEnum                 = new Guid("4621A4E3-F0D6-4773-8A9C-46E77B174840");
        public static readonly Guid Transfer                    = new Guid("5D080304-FE2C-48fc-84CE-CF620B0F3C53");
        public static readonly Guid PropertyStore               = new Guid("0384e1a4-1523-439c-a4c8-ab911052f586");
        public static readonly Guid ThumbnailHandler            = new Guid("7b2e650a-8e20-4f4a-b09e-6597afc72fb0");
        public static readonly Guid EnumItems                   = new Guid("94f60519-2850-4924-aa5a-d15e84868039");
        public static readonly Guid DataObject                  = new Guid("B8C0BD9F-ED24-455c-83E6-D5390C4FE8C4");
        public static readonly Guid AssociationArray            = new Guid("bea9ef17-82f1-4f60-9284-4f8db75c3be9");
        public static readonly Guid Filter                      = new Guid("38d08778-f557-4690-9ebf-ba54706ad8f7");
        public static readonly Guid EnumAssocHandlers           = new Guid("b8ab0b9c-c2ec-4f7a-918d-314900e6280a");
        public static readonly Guid FilePlaceholder             = new Guid("8677DCEB-AAE0-4005-8D3D-547FA852F825");
        public static readonly Guid FilePlaceholderMergeHandler = new Guid("3E9C9A51-D4AA-4870-B47C-7424B491F1CC");

        protected BHID() { }
    }
}