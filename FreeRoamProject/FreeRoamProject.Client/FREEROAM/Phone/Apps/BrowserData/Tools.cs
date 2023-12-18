namespace FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData
{
    public static class Tools
    {
        internal static void SetTextureDictionary(string txd)
        {
            ScaleformMovieMethodAddParamPlayerNameString(txd);
        }

        internal static void SetScaleformString(string text)
        {
            BeginTextCommandScaleformString(text);
            EndTextCommandScaleformString();
        }

        /// <summary>
        /// Get the selected index values from selections the user made in the scaleform
        /// </summary>
        /// <param name="bitwiseValue"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int GetValueFromBitwiseValue(int bitwiseValue, int start, int length)
        {
            int i = (1 << length) - 1;
            i <<= start;
            return (bitwiseValue & i) >> start;
        }

        /// <summary>
        /// Get the lowest value from the two provided, this is the same as the method used in the Scaleform
        /// </summary>
        /// <param name="normalPrice"></param>
        /// <param name="salePrice"></param>
        /// <returns></returns>
        public static int GetBestPrice(int normalPrice, int salePrice)
        {
            return salePrice >= 0 && salePrice < normalPrice ? salePrice : normalPrice;
        }
    }
}
