# StayAwake
small program to keep a windows computer awake.

- First is to set values for to be changed in the registry

          internal static partial class NativeMethods 
          {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

            [FlagsAttribute]
            public enum EXECUTION_STATE : uint
            {
                ES_AWAYMODE_REQUIRED = 0x00000040,
                ES_CONTINUOUS = 0x80000000,
                ES_DISPLAY_REQUIRED = 0x00000002,
                ES_SYSTEM_REQUIRED = 0x00000001

            }
          }

- Execute the process at startup

          public static void ForceSystemAwake()
          {
              NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS |
                                                    NativeMethods.EXECUTION_STATE.ES_DISPLAY_REQUIRED |
                                                    NativeMethods.EXECUTION_STATE.ES_SYSTEM_REQUIRED |
                                                    NativeMethods.EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
          }
          
          
- how to reset the values and return the computer to original status

          public static void ResetSystemDefault()
          {
              NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS);
          }
