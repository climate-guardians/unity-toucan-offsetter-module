using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class Offsetter : Variables
{
    // set chain: ethereum, moonbeam, polygon etc
    public string chain = "polygon";
    // set network mainnet, testnet
    public string network = "mumbai";
    // ChainId
    // String chainId = 80001;
    // smart contract method to call
    public string rpc = "https://rpc-mumbai.matic.today";

    public string[] methods = {"approve", "autoOffsetUsingToken", "calculateNeededTokenAmount"};

    string[] addresses = {"0x30dC279166DCFB69F52C91d6A3380dCa75D0fCa7", "0x7beCBA11618Ca63Ead5605DE235f6dD3b25c530E", "0xDd052AcA9AC1492a8b4F1432B68f11989903dE4d", "0xe11A86849d99F524cAC3E7A0Ec1241828e332C62", "0xA6FA4fB5f76172d178d61B04b0ecd319C5d1C0aa', '0x9c3C9283D3e44854697Cd22D3Faa240Cfb032889"};
    
    // String offsetHelper = addresses[0];
    // String nct = addresses[1];
    // String swapToken = addresses[2];

    // String usdc = addresses[3];
    // String weth = addresses[4];
    // String wmatic = addresses[5];
    long amount = 1000000000000000; // 0.001 ETH

    public async void SendTKey()
    {
        // private key of account
        string privateKey = "";
        // set chain: ethereum, moonbeam, polygon etc
        string chain = "polygon";// "ethereum";
        // set network mainnet, testnet
        string network = "mumbai";// "rinkeby";
        // account of player        
        string account = Web3PrivateKey.Address(privateKey);
        Debug.Log(account);
        // account to send to
        string to = "";
        // value in wei
        string value = "0";// "123";
        // optional rpc url
        string rpc = this.rpc;

        string chainId = "80001";// await EVM.ChainId(chain, network, rpc);
        Debug.Log(chainId);
        string gasPrice = "";// await EVM.GasPrice(chain, network, rpc);
        string gasLimit = "";// "21000";

        print(getAbiOffset());
        
        string[] argsCalculateNeededTokenAmount = { $"{addresses[4]}", $"{addresses[1]}", $"{amount}" }; // WETH to NCT amount

        string argsCalculateNeededTokenAmountSerialized = JsonConvert.SerializeObject(argsCalculateNeededTokenAmount);
        
        string dataCalculateNeededTokenAmount =  await Task.Run( async () => {
            return await EVM.CreateContractData(getAbiOffset(), this.methods[2], argsCalculateNeededTokenAmountSerialized);
        });

        Debug.Log("dataCalculateNeededTokenAmount:\n" + dataCalculateNeededTokenAmount);
        
        string transaction =  await Task.Run( async () => {
            return await EVM.CreateTransaction(chain, network, account, to, value, dataCalculateNeededTokenAmount /*data*/, gasPrice, gasLimit, rpc);
        });
        print(transaction);
        
        string signature = Web3PrivateKey.SignTransaction(privateKey, transaction, chainId);

        print(signature);

        string response =  await Task.Run( async () => {
            return await EVM.BroadcastTransaction(chain, network, account, to, value, dataCalculateNeededTokenAmount /*data*/, signature, gasPrice, gasLimit, rpc);
        });

        print(response);
    }


    // public async Task dummyFunction ( string dummyVariable) {
    //     await Task.Run( async () => autoOffsetUsingToken(chain, network, methods, addresses, amount));   
    // }

    public async void autoOffsetUsingToken(string chain, string network, string[] methods, string[] addresses, long amount ) {


        // Replace call with private key
        // string response = await Web3Wallet.SendTransaction(chainId, to, value, data, gasLimit, gasPrice);
        
        // Replace call with web3wallet
        string chainId = "80001";
        // string gasPrice = await EVM.GasPrice(chain, network, rpc);
        string gasPrice = "";
        string value = "0";
        string gasLimit = "";
        
        string[] argsCalculateNeededTokenAmount = { $"{addresses[4]}", $"{addresses[1]}", $"{amount}" }; // WETH to NCT amount

        string argsCalculateNeededTokenAmountSerialized = JsonConvert.SerializeObject(argsCalculateNeededTokenAmount);

        string dataCalculateNeededTokenAmount = await EVM.CreateContractData( getAbiOffset(), methods[2], argsCalculateNeededTokenAmountSerialized);
        Debug.Log("dataCalculateNeededTokenAmount:\n" + dataCalculateNeededTokenAmount);
        
        // calculateNeededTokenAmount
        string responseCalculateNeededTokenAmount = await Web3Wallet.SendTransaction(chainId, addresses[0], value, dataCalculateNeededTokenAmount, gasLimit, gasPrice);
        
        
        // TODO: Check what the response is and prepare to fit in the args
        Debug.Log(responseCalculateNeededTokenAmount);


        string[] argsApprovePoolContract = { $"{addresses[0]}", $"{responseCalculateNeededTokenAmount}" }; // allow offsetHelper to spend responseCalculateNeededTokenAmount
        string argsApprovePoolContractSerialized = JsonConvert.SerializeObject(argsApprovePoolContract);
        
        
        string dataApprovePoolContract = await EVM.CreateContractData(getAbiNCT(), methods[0], argsApprovePoolContractSerialized);
        Debug.Log("dataApprovePoolContract:\n" + dataApprovePoolContract);
        
        // approve Pool Contract
        string responseApprove = await Web3Wallet.SendTransaction(chainId, addresses[1], value, dataApprovePoolContract, gasLimit, gasPrice);
        Debug.Log(responseApprove);
        
        string[] argAutoOffsetUsingToken = { $"{addresses[4]}", $"{addresses[1]}", $"{amount}" }; 
        string argsAutoOffsetUsingTokenSerialized = JsonConvert.SerializeObject(argAutoOffsetUsingToken);

        string dataAutoOffsetUsingToken = await EVM.CreateContractData(getAbiOffset(), methods[1], argsAutoOffsetUsingTokenSerialized);
        Debug.Log("dataAutoOffsetUsingToken:\n" + dataAutoOffsetUsingToken);

        // autoOffsetUsingToken
        string responseAutoOffsetUsingToken = await Web3Wallet.SendTransaction(chainId, addresses[1], value, dataAutoOffsetUsingToken, gasLimit, gasPrice);
        Debug.Log(responseAutoOffsetUsingToken);
    }
}

