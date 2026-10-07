using LiveMap.Util;

namespace LiveMap.Render;

public class SepiaRenderer() : Renderer("sepia") {
    private static bool IsWater(int? id) => id == null || LiveMap.Api.SepiaColors.BlockIsWater[(int)id];
    private static byte GetIndex(int id) => LiveMap.Api.SepiaColors.Block2Color[id];
    private static uint GetColor(string id) => LiveMap.Api.SepiaColors.ColorsByCode[id];
    private static uint GetColor(int index) {
        // if (index <= 0) {
        if (index < 0) {
            Logger.Warn($"index is less than 0, cannot display color:{index}");
            GetColor("unknown");
        }

        if (index < LiveMap.Api.SepiaColors.ColorsByCode.Count) {
            uint colorCodeToReturn = LiveMap.Api.SepiaColors.ColorsByCode.GetValueAtIndex(index);
            Logger.Debug($"Returning the colorCode:{colorCodeToReturn}");
        }

        Logger.Debug($"yolo the ocean again when indexing sepia color:{index}");
        return GetColor("ocean");
    }

    public override void ProcessBlockData(int regionX, int regionZ, BlockData blockData) {
        if (TileImage == null) {
            return;
        }

        // Cache for previous row's block heights (y-values) used by ProcessShadowOptimized to avoid redundant calculations
        int?[] prevRowCache = new int?[TileConstants.RegionSize];
        // Cache for current row's block heights (y-values) used by ProcessShadowOptimized
        int?[] currentRowCache = new int?[TileConstants.RegionSize];

        for (int x = 0; x < TileConstants.RegionSize; x++) {
            // Swap caches: current row becomes previous row for next iteration
            (prevRowCache, currentRowCache) = (currentRowCache, prevRowCache);

            for (int z = 0; z < TileConstants.RegionSize; z++) {
                BlockData.Data? block = blockData.Get(x, z);
                if (block == null) {
                    currentRowCache[z] = null;
                    continue;
                }

                (int id, int y) = ProcessBlock(block);

                bool isWaterEdge = false;
                bool isWater = IsWater(id);
                if (isWater){
                    isWaterEdge =
                    IsWater(blockData.Get(x, z - 1)?.Top) &&
                      IsWater(blockData.Get(x + 1, z)?.Top) &&
                      IsWater(blockData.Get(x, z + 1)?.Top) &&
                      IsWater(blockData.Get(x - 1, z)?.Top);
                }

                uint color = isWaterEdge?
                    GetColor("wateredge") :
                    GetColor(GetIndex(id));

                // Use optimized shadow calculation
                float yDiff = ProcessShadowOptimized(x, y, z, blockData, prevRowCache, currentRowCache);

                TileImage.SetBlockColor(x, z, color, yDiff);

                // Update current row cache
                currentRowCache[z] = y;
            }
        }
    }
}
