import { CustomerModel } from "./customerModel";

export interface CustomerUsageModel{
    simCount: number;
    quotaSum: number;
    customer: CustomerModel;
}