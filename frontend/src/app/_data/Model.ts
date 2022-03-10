export default class Model {
    constructor(
        public name: string = 'Novi model',
        public description: string = '',
        public dateCreated: Date = new Date(),
        public datasetId?: number,

        //Test set settings
        public inputColumns: number[] = [0],
        public columnToPredict: number = 1,
        public randomTestSet: boolean = true,
        public randomTestSetDistribution: number = 0.10, //0.1-0.9 (10% - 90%)

        // Neural net training settings
        public encoding: Encoding = Encoding.Label,
        public type: ANNType = ANNType.FullyConnected,
        public optimizer: Optimizer = Optimizer.Adam,
        public lossFunction: LossFunction = LossFunction.MeanSquaredError,
        public inputNeurons: number = 1,
        public hiddenLayerNeurons: number = 1,
        public hiddenLayers: number = 1,
        public batchSize: number = 5,
        public inputLayerActivationFunction: ActivationFunction = ActivationFunction.Sigmoid,
        public hiddenLayerActivationFunction: ActivationFunction = ActivationFunction.Sigmoid,
        public outputLayerActivationFunction: ActivationFunction = ActivationFunction.Sigmoid
    ) { }
}

export enum ANNType {
    FullyConnected = 'potpuno povezana',
    Convolutional = 'konvoluciona'
}

export enum Encoding {
    Label = 'label',
    OneHot = 'one hot'
}

export enum ActivationFunction {
    Relu = 'relu',
    Sigmoid = 'sigmoid',
    Tanh = 'tanh',
    Linear = 'linear'
}

export enum LossFunction {
    BinaryCrossEntropy = 'binary_crossentropy',
    MeanSquaredError = 'mean_squared_error'
}

export enum Optimizer {
    Adam = 'adam'
}