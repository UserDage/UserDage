//组件通信中心
var vs = new Vue()
//搜索组件
Vue.component('search-info', {
    data: function () {
        return {
            SearchName: '',
        }
    },
    template: `
<div style='width:380px'>
<template>
<span style='font-size:small'>职位名称：</span><el-input v-model='SearchName' size='small' style="width:180px"></el-input>
<el-button type='primary' icon="el-icon-search" size='small' v-on:click='search'>搜索</el-button>
</template>
</div>
`, methods: {
        search() {
            var currPage = 1
            var pagesize = 5
            var val = this.SearchName
            axios.post('DutysPageData', { currentPage: currPage, pagesize: pagesize, DutyName: val }).then((result) => {
                var data = result.data.DutysInfo
                var total = result.data.total
                var pagecount = result.data.pagecount
                vs.$emit('duty-search', data, total, pagecount, val)
            }).catch((error) => {
                console.log(error)
            })
        }
    }
})
//新增职位组件
Vue.component('add-duty', {
    template: `<el-link icon="el-icon-circle-plus-outline" v-on:click="AddDuty" style="margin-top:-25px;margin-bottom:-10px"><h4>添加新部门</h4></el-link>`,
    methods: {
        AddDuty() {
            vs.$emit('add-dutys', true)
        }
    }
})
//分页组件
Vue.component('page-com', {
    data: function () {
        return {
            currentPage: 1,//当前页
            pagesize: 5,//每页显示多少条,
            total: 0,//总共有多少条数据
            pagecount: 0,//总共有多少页
            DutyInfo: [],//分页请求的数据
            SearchName: ''
        }
    }, methods: {
        GetPageData(index) {//当前页发生改变，请求数据
            var currentPage = index
            var pagesize = this.pagesize
            var name = this.SearchName
            axios.post("DutysPageData", { currentPage: currentPage, pagesize: pagesize, DutyName: name }).then((response) => {
                this.DutyInfo = response.data.DutysInfo
                this.pagecount = response.data.pagecount
                this.total = response.data.total
                vs.$emit('duty-data', this.DutyInfo, this.currentPage, this.pagesize)
            }).catch((error) => {
                console.log(error)
            })
        }, GetNewData(index) {//当页面显示条数发生改变重新加载数据
            var currentPage = this.currentPage
            var pagesize = index
            var name = this.SearchName
            axios.post("DutysPageData", { currentPage: currentPage, pagesize: pagesize, DutyName: name }).then((response) => {
                this.DutyInfo = response.data.DutysInfo
                this.pagecount = response.data.pagecount
                this.total = response.data.total
                vs.$emit('duty-data', this.DutyInfo, this.currentPage, this.pagesize)
            }).catch((error) => {
                console.log(error)
            })
        }
    },
    template: ` <el-pagination :total="total"
                       :page-size="pagesize"
                        v-on:size-change="GetNewData"
                        v-on:current-change="GetPageData"
                       :page-count="pagecount"
                       :current-page.sync="currentPage"
                       :page-sizes="[5,10,20,30]"
                       layout="total,sizes,prev,pager,next,jumper">
        </el-pagination>`,
    mounted: function () {
        vs.$on('duty-search', (data, total, pagecount, name) => {
            this.currentPage = 1
            this.total = total
            this.pagecount = pagecount
            this.SearchName = name
        })
        vs.$on('updated-data', (data, currentPage, pagesize) => {
            this.DutyInfo = data
            this.currentPage = currentPage
            vs.$emit('duty-data', this.DutyInfo, this.currentPage, this.pagesize)
        })
        vs.$on('deleting-data', (currentPage, pagesize) => {
            this.currentPage = currentPage
            var name = this.SearchName
            if (this.SearchName != null) {
                axios.post('DutysPageData', { currentPage: currPage, pagesize: pagesize, DutyName: name }).then((result) => {
                    this.DutyInfo = result.data.DutysInfo
                    this.total = result.data.total
                    this.pagecount = result.data.pagecount
                    vs.$emit('duty-data', this.DutyInfo, this.currentPage, this.pagesize)
                }).catch((error) => {
                    console.log(error)
                })
            } else {
                axios.post('DutysPageData', { currentPage: currPage, pagesize: pagesize }).then((result) => {
                    this.DutyInfo = result.data.DutysInfo
                    this.total = result.data.total
                    this.pagecount = result.data.pagecount
                    vs.$emit('duty-data', this.DutyInfo, this.currentPage, this.pagesize)
                }).catch((error) => {
                    console.log(error)
                })
            }
        })
        var currPage = this.currentPage
        var pagesize = this.pagesize
        axios.post('DutysPageData', { currentPage: currPage, pagesize: pagesize }).then((result) => {
            this.DutyInfo = result.data.DutysInfo
            this.total = result.data.total
            this.pagecount = result.data.pagecount
            vs.$emit('duty-data', this.DutyInfo, this.currentPage, this.pagesize)
        }).catch((error) => {
            console.log(error)
        })
    }
})
//表格组件
Vue.component('table-com', {
    data: function () {
        return {
            DutysInfo: [],
            loading: true,
            currentPage: '',
            pagesize: ''
        }
    },
    template: ` <el-table :data="DutysInfo" v-loading="loading" style="width:max-content" highlight-current-row>
            <el-input v-model="DutysInfo.DutyID" hidden></el-input>
            <el-table-column type="index" label=" " width="50px"></el-table-column>
            <el-table-column prop="DutyName" label="职位名称" width="220px">
            </el-table-column>
            <el-table-column prop="DutyMark" label="职位描述" width="220px"></el-table-column>
            <el-table-column width="220px">
                <template slot="header" slot-scope="scope">
                    操作
                </template>
                <template slot-scope="scope">
                    <el-link icon="el-icon-edit" type="text" v-on:click="EditorAdd(scope.row)">编辑</el-link>
                    <el-link icon="el-icon-delete" type="danger" v-on:click="Delete(scope.row)">删除</el-link>
                </template>
            </el-table-column>
        </el-table>`,
    mounted: function () {
        vs.$on('duty-data', (data, currentPage, pagesize) => {
            this.DutysInfo = data
            this.pagesize = pagesize
            this.currentPage = currentPage
            this.loading = false
        })
        vs.$on('duty-search', (data, currentPage, pagesize) => {
            this.DutysInfo = data
            this.pagesize = pagesize
            this.currentPage = currentPage
            this.loading = false
        })
    }, methods: {
        EditorAdd(row) {
            var IsVisible = true
            var DutyID = row.DutyID
            vs.$emit('edit-me', IsVisible, DutyID, this.currentPage, this.pagesize)
        },
        Delete(row) {
            this.$confirm('此操作将永久删除该数据, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }).then(() => {
                axios.post('Delete', { id: row.DutyID })
                    .then((response) => {
                        var isno = response.data
                        if (isno) {
                            //删除成功后从原数组过滤掉与已删除数据ID相同的数据，返回新的数组
                            var currentPage = this.currentPage
                            var pagesize = this.pagesize
                            vs.$emit('deleting-data', currentPage, pagesize)
                            this.$message({
                                type: 'success',
                                message: '删除成功!'
                            });
                        } else {
                            this.$message({
                                type: 'error',
                                message: '删除失败!'
                            });
                        }
                    })
                    .catch((error) => {
                        console.log(error);
                    });
            }).catch(() => {
                this.$message({
                    type: 'info',
                    message: '已取消删除'
                });
            });
        }
    }
})
//dialog窗口组件
Vue.component('edit-com', {
    data: function () {
        return {
            rules: {//表单验证规则
                DutyName: [{ required: true, message: '部门名称不能为空', trigger: 'blur' }],
                DutyMark: [{ required: true, message: '部门描述不能为空', tirgger: 'blur' }]
            },
            Operation: "",//dialog窗体标题，显示正在进行的操作
            IsDialog: false,//是否显示dialog窗体
            DialogFormData: {
                DutyID: 0,
                DutyName: "",
                DutyMark: ""
            },
            currentPage: '',
            pagesize: ''
        }
    }, template: ` <el-dialog :title="Operation"
                   :visible.sync="IsDialog"
                   width="400px">
            <el-form :model="DialogFormData" style="margin-top:-90px;text-align:center" :rules="rules" :ref="DialogFormData">
                <el-form-item style="visibility:hidden">
                    <el-input hidden v-model="DialogFormData.DutyID"></el-input>
                </el-form-item>
                <el-form-item label="职位名称" prop="DutyName">
                    <el-input v-model="DialogFormData.DutyName" style="width:240px"></el-input>
                </el-form-item>
                <el-form-item label="职位描述" prop="DutyMark">
                    <el-input v-model="DialogFormData.DutyMark" style="width:240px"></el-input>
                </el-form-item>
                <div solt="footer" class="dialog-footer" style="text-align:center">
                    <el-button type="primary" v-on:click="submit(DialogFormData)">确定</el-button>
                    <el-button type="info" v-on:click="IsDialog=false">取消</el-button>
                </div>
            </el-form>
        </el-dialog>`, mounted: function () {
        vs.$on('edit-me', (IsVisible, DutyID) => {
            this.Operation = "职位编辑"
            this.IsDialog = IsVisible
            this.DialogFormData.DutyID = DutyID

            axios.post('DutysJson', { id: DutyID }).then((result) => {
                this.DialogFormData.DutyName = result.data.DutyName
                this.DialogFormData.DutyMark = result.data.DutyMark
            })
        })
        vs.$on('add-dutys', (IsVisible) => {
            this.Operation = "新增职位"
            this.IsDialog = IsVisible
            this.DialogFormData.DutyID = 0
            this.DialogFormData.DutyName = ''
            this.DialogFormData.DutyMark = ''
        })
        vs.$on('duty-data', (data, currentPage, pagesize) => {
            this.currentPage = currentPage
            this.pagesize = pagesize
        })
    }, methods: {
        submit(DialogFormData) {
            this.$refs[DialogFormData].validate((valid) => {
                if (valid) {
                    var data = new Object()
                    data.DutyID = DialogFormData.DutyID
                    data.DutyName = DialogFormData.DutyName
                    data.DutyMark = DialogFormData.DutyMark
                    axios.post('AddorUpdate', { dutys: data }).then((result) => {
                        if (result.data == true) {
                            if (this.DialogFormData.DutyID > 0) {
                                this.$message({
                                    type: 'success',
                                    message: '修改成功！'
                                })
                            } else {
                                this.$message({
                                    type: 'success',
                                    message: '新增成功！'
                                })
                            }
                            var currentPage = this.currentPage
                            var pagesize = this.pagesize
                            axios.post("DutysPageData", { currentPage: currentPage, pagesize: pagesize }).then((response) => {
                                vs.$emit('updated-data', response.data.DutysInfo, currentPage, pagesize)
                            }).catch((error) => {
                                console.log(error)
                            })
                            this.IsDialog = false
                        } else {
                            if (this.DialogFormData.DutyID > 0) {
                                this.$message({
                                    type: 'error',
                                    message: '修改失败！'
                                })
                            } else {
                                this.$message({
                                    type: 'error',
                                    message: '新增失败！'
                                })
                            }
                            this.IsDialog = false
                        }
                    }).catch((error) => {
                        console.log(error)
                    })
                } else {
                    return false
                }
            })
        }
    }
})
let vm = new Vue({
    el: '#app'
})