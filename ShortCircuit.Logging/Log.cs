namespace ShortCircuit.Logging
{
    public static class Log
    {
        // 基本はDIだとしてもグローバルなロガーはあると便利
        //public static ILogger Logger;

        // デバッグ
        // Androidっぽいのがタイプ数が少なくて便利そうだった
        public static void D()
        {
            // メソッドの呼び出し位置やファイル名なども含めたい
            // Loggerとは別にデバッグ出力にも出したい
            throw new NotImplementedException();
        }

        // キューで処理できるようにしたい
        // ウォッチドッグ
        // 非同期出力

        // ファイル出力の場合はローリングもサポート
        // 日付ファイル名でのローリングもあったほうがよいか

        // 構造化ログにしたい
        // ログ出力先にDBがあったほうがよい？
        // でもわざわざ用意したくないので、SQLiteなどを使う？

        // NLog, Serilogあたりを参考にしたい
        // 複雑にするとめんどくさいので何も考えずに使えるようにしたい
    }
}