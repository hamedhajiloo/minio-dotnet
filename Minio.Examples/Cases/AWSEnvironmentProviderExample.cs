/*
 * MinIO .NET Library for Amazon S3 Compatible Cloud Storage,
 * (C) 2021 MinIO, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Threading.Tasks;

using Minio.Credentials;
using Minio.DataModel;
using Minio.Exceptions;


namespace Minio.Examples.Cases
{
    public class AWSEnvironmentProviderExample
    {
        // Establish Credentials with AWS IAM Credentials in Environmental variables
        public async static Task Run()
        {
            AWSEnvironmentProvider provider = new AWSEnvironmentProvider();
            MinioClient minioClient = new MinioClient()
                                                .WithEndpoint("s3.amazonaws.com")
                                                .WithSSL()
                                                .WithCredentialsProvider(provider)
                                                .Build();
            try
            {
                StatObjectArgs statObjectArgs = new StatObjectArgs()
                                                            .WithBucket("my-bucket-name")
                                                            .WithObject("my-object-name");
                ObjectStat result = await minioClient.StatObjectAsync(statObjectArgs);
                Console.WriteLine("Object Stat: \n" + result.ToString());
            }
            catch (MinioException me)
            {
                Console.WriteLine($"[Bucket] IAMAWSProviderExample example case encountered Exception: {me}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket] IAMAWSProviderExample example case encountered Exception: {e}");
            }
        }
    }
}