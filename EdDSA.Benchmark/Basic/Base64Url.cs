﻿using BenchmarkDotNet.Attributes;
using EdDSA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdDSA.Benchmark.Basic;

[MemoryDiagnoser]
public class Base64Url
{
    private byte[] data;
    private string base64urlEncoded = "rYJT6o4CkF7Q36uTrbzMyc4UZVBGI9qGqOIPZ3Ce_OCgwjnqAI7G4YGs-YIt1iaFLe5k4wHpLQoq2lZmdUo4TMnW_aJs_FK9JU8EP1zai5UwrK75b3cAGFvYYokPXM6vGq4g02tXmfh9FHfoouqnBiflhVYQ_qu_yBuFC2odl5xqWg2hDdSb7sAH0UE9gmrQrOYtD1z-mgpxokL6jthAlkqVCG5a8AQz54rxC6Xj812AYq5ADJLkNQ-hGJrFuJQMSPNY8uFaVDxJ0kyjepv097GjDkLaElC2QFvoOrg-eLDbWsqNX-W6AO-lMRfUovKzQicpOMYz85Q4W3GBJf3eJAmeaeaC4eCnfuC2xCmZ1u_la-liGALRyzVWgGoVnGMjl8Aj8pFCFUZLj6IpX1QTQhMVlO-sqsW76aSzhWKj5yb7m8mgdUaRW4471HLb9_HKQwzDp5B4kX-W7ZR0svn4E1gI_a01ikE4RejIBQrEfsa79h99LHUyUKHvoQ5waJXumpsDLXMP5lG96zwP-H-JnxN7cwhC_M2ok3JCB-auY4XZ4UFAFYvUZVzhcKDKsbkKhXaU3Y0t6lu6tIph-Nux_REF8whCYvGeLldf5kEMP3oIJNVLiNRskXf5GVVh8On3kRAaoKM98DfN2nlQXYhrkL6gqoFzcqTkqkxixtFQrD7AYrQbhj7TXLtVST5aJ1mDkgcZ3oX5kxs7JSzFPEkzHA60Fx6y89nKyCQ8dQBfgmx8queKnzCn42MY1pGfT_4JsbBa0wAaqpk1YglVd8sQ4930_e_gPRFDRE4a9Ph9iZf95OEgjF3LUf_fUSLxkMYQicEGYPa3BhcfSvxIMEq2BRb7ec_R--lGGKD_oz9qik0NjqDs1n2YzG3VaekzU3GkAhswD68P7Vy3XV4bBuS3ano1xYFrQd7j1cDVokv7rOgNLvI4t1xUcfUXRTUcCv8RbXETt0jnCqsPn7-QfCatk9oWt86x1Zq-8ZSPdVcBJi93vSQKajZnmlpaLg6eruIQFCkDhTByCveKoUhBdi8PV5V2ZJoVqmpmXNKGfjTVJpSmkDjLGSg1KDzDSMAeaaRt_Mu5AbD5eHkiyl0dGVOLllSmve2d9auUEk5hSNskhz4I77Ezcn7HeYWvb0dLQtff6KR4J7wmL1MdAJ6YoNDAnyi7P7wG1lyP_dPoIqWtNOsUiuDIHWyeNGETCgBFsWy16hhGw4uEbKpejObLbc5Nn383Ci4lejmM3Ki8UxxiQk0rgQdWV4PCHkscVePWUxmhKDZlJ5BcmyKQXfQ-jgN0EFMtqW4KtnkJkoqpOX8nrHlaD83RVEn0gDR8vPMU5defYiIg-HEvKQrT6O_7kKm8Tzu37cf9YzNzEXb5pZjLKVOU4KBX-VCzW-7OmL_qAYzBnBUTFBxpvUjhUkyKr0PG66Ud3evO679wSwUHE8Q4-MfZzGWciUPTgV5GrrLhrfZjd0zoUNK7DcKYO20wxXOUSMK51geJxQgmDfWYiMffUOemj3LrzzYA0hYVgHvCa78y_A1HwlGpitkvJysbPGCBualo2wSKVJ00iA7rL8YGfqy-Ec37ftL9tBeXO4e828vhjeapRM85_2QKahQHXItIpubcKX0-e_Ecr18B6_byIzgOxHrch6CwCC6EvT3tbdjIAh_lnLYL6EZKwojpAZZ_6uGNq5kJC2V0dHaI6NPw2Ec-GcFAoSfwPpYrp7CMmsqa8s4kUx11THtR7aeUDKxx9ogTYG-BbPfd5PLS2Wv6akGACgKokxg-4u--vQomBGinvYDePCxH6jsjBzZBzSBrT_R31bJRJ7AsV6bNJ19d0ygJYrt480kTSnKsJvUF1fZzdqTzA8jz4sfsa9USvK7GCuPdC_2wP9Jbt2OzZpZQgRc42sJk41QodUxpmhBz-3u9n5_y-sr7xQ9QWgehbLDie-ys-VfERiOGWTIEjJogBS5QxNLFFkq1WXznZG3e1gHCh1l2YRBrDVVubju5IdM9UvznKPeaN8wSZSXLlIu04ikB3wFDu9FtXn-vhICsZ0jTcXuDSyqiuuJQQpVxd5oVcRY31ZTeRBrdpcDQB0bijAZw8xcZsY--fD9qFOPFmGr0FZiO5IJLQpKrsRWmk5cfFUw-GfK7YJjyEwKrsvzUVy7OAQIAvvQeOYdNXKd--fEpSBJZmCxgiZE4VOC6vUYhCW3VYkqMRxar3M6HBIFb1XnYEnvNsv_Wny7jp3b4yXndVDH7Sx6I6bUxGDx1VcfhzenQSUu7czPEP8MiTawo1A24Pd_yilOMOFp4KRhpBZmnO_ytktKqG3o5jwx80_5pKOjVsvtnuBIff_9MJBjnUliEGfIUsh09vVcEyBTel1uziZ1hggviEypO5gG7N_GLltz5WV_3OsEUQARM08KoG2cpLbUHykS6g4OyAZrFFlsRFoegVWTvsBjN96Clncqy_N8fXSbkrZGe47mA5fmc3kFRxcE8AExfxEPR_7V_yR49BGZUk_iIA4r6Z7WLpK3VoAl3-XqqYwTeFoyE0Denxu5jdU7yJ_aSmjzbEP5gxT3wyHdjcLgU5GpyuEZ9E-J86ObaJg52EsVCPjgBwbPCr-pJl38VZj3gAZjddeCDY9WnGwywOUzLjZPAfD2bQMdRmOzJJivJOaZz_MuMZ8PG2k-OqhRvwgP5ZVpcHEymhuXoQQpc65OSc2T2z8rHPCn8pOiyFXhNRvzw_nWCxafVVrrXERWfKUv77JkFsJeODYliCTVYAxnhmrjqTNA5ROYAJJK7u3f75FqirQY6WwXbTi4WFPXnnBhanj47RhqUGgbnP5jyX1Fg_m-itLlxcMwtDLqSBaWOVXpYawnZYmHxHoYn3NfaHrPbNVUwEIwxzGCVFMk2sx3esfDLQDhGS4G3NQ8DF4o-_LLEWXrBwU3Ej3VW_l_GF0vzPGlrl6qQStyd2wgrMx-9r6CdQmKQS33g9FgNtOQwfIo2x95PlneQV_b6eenqH-Fw-wPCpePmJL-UA4sos5EoOKL2yCY5xbn2WJFlWAo8s_4YsJz9CEqEVkvbLmITTZtLqkQoCFAnbozTD-140qv091OTDsaFpanfFRwMun6_S77uY4x-ImHVsOGVAW6nbsTDG5EOUoXGBHIEVqoy3xuc9Zk_KxAuVdDuCocUTOTrBLOSeBJSl3-H96ZPgzNMI9N673cN8cnbeap5wLi6tXWDivVi9zoKQYWSxcB5CSIT6SHm-ygkVt_Xi5b-BHHXGvh_OVX8EQLM5wpNFhVxgPgZN6IlYKLHZnH1OixJCl0c9W122p7nvW8bWCh920LEWw8ldIu8gaKF2lXG4v8_DjUHnf3ELK7oWmKDzNNE4F6bTtKerjv4AySXCeHVpMDO2HGbIDDtvHKeSy4cpA4cRZbaNXweQziwhwxWSSPp2slADsJ1TVUkuHcpssXsqIzrQ91ARTaaA7hWO0PLZdW8SXhgKWWlqseb1Qdjw092LaIezpcPX4xYK8Tsj4Narc8bY_KxSgQlrDE9yMt6fXTGsb9fNwJVsdpz3i4IOxEgwj67NwRwPvaJ9NprX0sQUfkXAguRTILT1QzSugcAXrjW8fpV8cyH02sEE4xbuPRC5p34MlZgrDm9Y-DT85YLeZPQqmNLMr4JqG9D-C_bPyh2MCPE-tGrjb4tK3MJy-pJpf8dmCeEBS8zd9wiLlc8yC72GvkZP9GSYhecQ7JsVsrDGoEKqF_HTCCPY1wjscKFCjeTrcS71TTiqywxIF-O9_Wr728NSCqEqEuQsDpWRuda_3BICs54Ls16MOJGnlVPv3if9v2rhz-rsVV72pu_PG785HVcMdukRUDd7G8JViTomcOG84xNR4b9mrvlofZ-v0bATkeQxfltCZVnnwk3aealnAeX3mZLE-khXApu8BUhFpPeL5q8c0nGj69_vc59kOY-j0B1vyZM0-1YGPh9deaNHpEZWH7QJ7shMcym7SN5_05hJcBaoHNTa1tWDM6NXv_Y1ISFZzPVO0NG8rYxjxN2S8CArVGGHzyh1oQOkx9AKKZ5knjWZyg29NaepeYtKwlEaeBs5nModHqkcnSBvwuNTtM6LQS0KHjAJs9s1pbJ66rWhssFXJCHKHNj9Wg5fBOTlKPpqwDDfS3DhX-9nfQ42m3goZ3s5Ei4wiiBKf26IjU6HI0QVc9C6i0KRysSimCCZbMCripBVTVwHHg6ipirEwukkaZO646udyBLJMjaHVdxKZpKgB7QHGnIvjmE2-0hzfHdEqWIWtLeeke6qH2siE0muWWIqO1qXqcpHf9MBIysALVTipnE16WuCwjwhrFb_xmvBIUMHEhWoHXiADZ3kE3WfXha01C7Vo6Hr5d5nhLRt99mh-Fk3OYKuaOPrSQR-Q8O3L5KwoSDNuvTJy8L6ChsPDr_t9HRfTM3_8nb225eSxK54FAj1pUJOmlX-54IY9aO4lC8kTY4wvJJ80ypw9wUytFujge3bS0fqqleEGlG7x6iGbDdKkxmGjDIfrZtTdXykGCIunmXoqNGUWKuT4Ut3V058_-QzLA5-r3b5WBBFjltknOnVPpdW7uCA8m3LS4JnlW5FXltXy4KTrtHwJ1OKuP-8UQifnFkS9j9QwwhiSaRw_QQ283FyNP7jQJQMnPmsm3PG28eMBw4248DlASKsBaNOifiKrFPsZpwmdZgyDG0YLmjSrFaN0GU4WG1L5rSct1AJAAwSZbGwL8cmi9D2aFEWgimPBxbMB_bkM8wb31zMQorX_UZTGRAeyQSSyF2dHOwm1kpXiYt5fvYTfdRDedUQS7_oojGSXoZr3NVkCsGsn0XdKE6iz73HC3xZK_MSmwsK-rIqnbyi6LIKHeE3fn9f6wUjJAgoX2dvVUyAF22wgBjMPwNLO55kGfP61LYQBkPbLdKoW9J-I7JfDd12vdH7cHL1l4ET_11FQ0twXj_DZSEg7oDflNiQILUSK29hFAW5OVqGQPlEyfQ1rwey2e7cmdS4RjdgnlW3iSCClC6_lIgtbIsNwxt4HFIAm8yYaJTy-sT2rVtxSfsjnYOE9PdKK4cHCGhqoV0R4r7CS4WXugAkAckhxfyv371-TpFgNz5DGDK6uu9CjPa8IMJhLJy3o7zATOKhH_e_-wVqAhXdgQa0p-p_mUkLMGiid4B_U5-dZ4e2yshreloh4nlAJdhENz_PxOAMKQaDC6B7WIPjInnWgO3kKiPoobQPvpyXsmku-jsicpcCxuFdiTGmaXC9mO6OR7eQo0SjKc5TsvNxQRW4d-hYgySjMCYgFj_mJt5RqdM9PopthDEn7OzjNFg0Ngy97ozpNi7g7o2TMRX-K24V8kkERVH1nUQ3kNsfI2P8lDYfUmxzMz4dWtefsjM6YCIHe9thQe6Qm26KZfOK2nVjppmQb5qeJAT9xxb5qMh1udLxYtFdSODDiMMycXk6Pg-S79lQxsW1oGGYfWgvKIZHmpJEw";

    public Base64Url()
    {
        data = new byte[4096];
        new Random().NextBytes(data);
    }


    [Benchmark]
    public string Base64UrlEncode()
        => Base64UrlEncoder.Encode(data);

    [Benchmark]
    public byte[] Base64UrlDecode()
        => Base64UrlEncoder.Decode(base64urlEncoded);
}
